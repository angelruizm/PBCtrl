// Copyright © 2010 Phil Booth
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PB
{
	/// <summary>
	/// An intuitive editable ListBox control. Edit mode is accessed by
	/// double-clicking on the control or pressing Enter when an item
	/// is selected. Once you're in edit mode, the up and down cursor
	/// keys can be used to cycle through the different items without
	/// committing any changes that are made. Tab and Shift+Tab can be
	/// used to cycle through the items, committing any changes that
	/// are made as you go along. Pressing Enter will commit changes
	/// and leave edit mode. Pressing Esc or simply navigating away from
	/// the edit region will leave edit mode without committing changes.
	/// </summary>
	[Category("PB Controls"), Description("An intuitive, editable list box control.")]
	public partial class EditableListBox : UserControl
	{
		public EditableListBox()
		{
			InitializeComponent();
			listboxHelper = new ListboxHelper(listbox);
			textboxHelper = new TextboxHelper(textbox);
			buttonsHelper = new ButtonsHelper(new Button[5] { buttonSort, buttonUp, buttonDown, buttonAdd, buttonRemove });
		}

		#region Properties
		[Description("Indicates whether the EditableListBox will display a horizontal scroll bar for items beyond the right edge of the EditableListBox.")]
		public bool HorizontalScrollbar
		{
			get { return listboxHelper.horizontalScroll; }
			set { listboxHelper.horizontalScroll = value; }
		}

		[Description("Indicates the width, in pixels, by which an EditableListBox can be scrolled horizontally. Only valid if HorizontalScrollbar is true.")]
		public int HorizontalExtent
		{
			get { return listboxHelper.horizontalExtent; }
			set { listboxHelper.horizontalExtent = value; }
		}

		[Description("Indicates whether the EditableListBox should always have a scroll bar present, regardless of how many items are in it.")]
		public bool ScrollAlwaysVisible
		{
			get { return listboxHelper.alwaysShowScroll; }
			set { listboxHelper.alwaysShowScroll = value; }
		}

		[Description("Indicates whether values should be displayed in columns horizontally.")]
		public bool MultiColumn
		{
			get { return listboxHelper.multiColumn; }
			set { listboxHelper.multiColumn = value; }
		}

		[Description("Indicates how wide each column should be in a multi-column EditableListBox.")]
		public int ColumnWidth
		{
			get { return listboxHelper.columnWidth; }
			set { listboxHelper.columnWidth = value; }
		}

		[Description("Indicates whether tab characters should be expanded to spaces.")]
		public bool UseTabStops
		{
			get { return listboxHelper.showTabs; }
			set { listboxHelper.showTabs = value; }
		}

		[Description("Indicates whether items in the EditableListBox should be sorted alpha-numerically.")]
		public bool Sorted
		{
		    get { return listboxHelper.isSorted; }
		    set { listboxHelper.isSorted = value; }
		}

		[Description("The collection of items in the EditableListBox.")]
		public ListBox.ObjectCollection Items
		{
			get { return listboxHelper.items; }
		}

		[Description("Gets or sets the zero-based index of the currently selected item in the EditableListBox.")]
		public int SelectedIndex
		{
			get { return listboxHelper.selectedIndex; }
			set { listboxHelper.selectedIndex = value; }
		}

		[Description("Indicates the size of the EditableListBox buttons.")]
		public SimpleSize ButtonSize
		{
			get { return buttonsHelper.ButtonSize; }
			set
			{
				if(buttonsHelper.ButtonSize != value)
				{
					buttonsHelper.ButtonSize = value;

					if(value == SimpleSize.Large)
					{
						buttonsHelper.icons = imagelistLargeButtons;
						listboxHelper.reduceHeight(ButtonsHelper.dimensionsDiff);
					}
					else
					{
						buttonsHelper.icons = imagelistSmallButtons;
						listboxHelper.increaseHeight(ButtonsHelper.dimensionsDiff);
					}
				}
			}
		}

		[Description("Indicates whether the EditableListBox is empty or populated.")]
		public bool Empty
		{
			get { return listboxHelper.isEmpty; }
		}

		[Description("Indicates the value of the currently selected item in the EditableListBox.")]
		public string SelectedItem
		{
			get { return listboxHelper.selectedItem; }
			//set { listboxHelper.selectedItem = value; }
		}
		#endregion

		#region Events
		#region Data events
		public class DataEventArgs : EventArgs
		{
			public DataEventArgs(int itemIndex, string item)
			{
				ItemIndex = itemIndex;
				Item = item;
			}

			public readonly int ItemIndex;
			public readonly string Item;
		}

		public delegate void DataEventHandler(object sender, DataEventArgs evt);

		[Category("Data"), Description("Occurs when a new item is added to the EditableListBox.")]
		public event DataEventHandler AddItem;

		[Category("Data"), Description("Occurs when an item is removed from the EditableListBox.")]
		public event DataEventHandler RemoveItem;

		[Category("Data"), Description("Occurs when an item in the EditableListBox is moved up.")]
		public event DataEventHandler ShiftUpItem;

		[Category("Data"), Description("Occurs when an item in the EditableListBox is moved down.")]
		public event DataEventHandler ShiftDownItem;

		[Category("Data"), Description("Occurs when an item in the EditableListBox is edited.")]
		public event DataEventHandler EditItem;

		private void fireDataEvent(DataEventHandler handler, int itemIndex, string item)
		{
			if(handler != null)
				handler(this, new DataEventArgs(itemIndex, item));
		}
		#endregion

		#region Sort events
		public class SortEventArgs : EventArgs
		{
			public SortEventArgs(SortOrder order)
			{
				Order = order;
			}

			public readonly SortOrder Order;
		}

		public delegate void SortEventHandler(object sender, SortEventArgs evt);

		[Category("Sort"), Description("Occurs when items in the EditableListBox are sorted or unsorted.")]
		public event SortEventHandler SortItems;

		private void fireSortEvent(SortOrder order)
		{
			if(SortItems != null)
				SortItems(this, new SortEventArgs(order));
		}
		#endregion
		#endregion

		#region Key handling
		protected override bool ProcessDialogKey(Keys keyData)
		{
			if(textbox.Focused)
			{
				if(onTextboxKey(keyData))
					return true;
			}
			else if(listbox.Focused)
			{
				if(onListboxKey(keyData))
					return true;
			}

			return base.ProcessDialogKey(keyData);
		}

		private bool onTextboxKey(Keys keyData)
		{
			switch(keyData)
			{
				case Keys.Enter:
					updateItem();
					goto case Keys.Escape;

				case Keys.Escape:
					finishEditing();
					listboxHelper.focus();
					return true;

				case Keys.Tab:
					updateItem();
					goto case Keys.Down;

				case Keys.Down:
					nextItem();
					editItem();
					return true;

				case Keys.Shift | Keys.Tab:
					updateItem();
					goto case Keys.Up;

				case Keys.Up:
					previousItem();
					editItem();
					return true;
			}

			return false;
		}

		private bool onListboxKey(Keys keyData)
		{
			switch(keyData)
			{
				case Keys.Enter:
				case Keys.Space:
					editItem();
					return true;
			}

			return false;
		}
		#endregion

		#region Mouse handling
		private void listbox_DoubleClick(object sender, EventArgs e)
		{
			selectItem(((MouseEventArgs)e).Location);

			fireDataEvent(AddItem, listboxHelper.selectedIndex, listboxHelper.selectedItem);

			editItem();
		}

		private void buttonSort_Click(object sender, EventArgs e)
		{
			listboxHelper.sort();

			fireSortEvent(listboxHelper.order);
		}

		private void buttonUp_Click(object sender, EventArgs e)
		{
			fireDataEvent(ShiftUpItem, listboxHelper.selectedIndex, listboxHelper.selectedItem);

			listboxHelper.raiseSelectedItem();
		}

		private void buttonDown_Click(object sender, EventArgs e)
		{
			fireDataEvent(ShiftDownItem, listboxHelper.selectedIndex, listboxHelper.selectedItem);

			listboxHelper.lowerSelectedItem();
		}

		private void buttonAdd_Click(object sender, EventArgs e)
		{
			listboxHelper.addNewItem();

			fireDataEvent(AddItem, listboxHelper.selectedIndex, listboxHelper.selectedItem);

			editItem();
		}

		private void buttonRemove_Click(object sender, EventArgs e)
		{
			fireDataEvent(RemoveItem, listboxHelper.selectedIndex, listboxHelper.selectedItem);

			listboxHelper.removeItem();
		}

		private void textbox_Leave(object sender, EventArgs e)
		{
			updateItem();
			finishEditing();
		}
		#endregion

		private void selectItem(Point point)
		{
			listboxHelper.selectItem(point);
		}

		private void editItem()
		{
			textboxHelper.show(new Rectangle(listboxHelper.selectionRectangle.X + listboxHelper.location.X, listboxHelper.selectionRectangle.Y + listboxHelper.location.Y, listboxHelper.selectionRectangle.Width, listboxHelper.selectionRectangle.Height), listboxHelper.selectedItem);
		}

		private void finishEditing()
		{
			textboxHelper.hide();
		}

		private void updateItem()
		{
			fireDataEvent(EditItem, listboxHelper.selectedIndex, listboxHelper.selectedItem);

			listboxHelper.updateSelectedItem(textbox.Text);
		}

		private void nextItem()
		{
			listboxHelper.selectNextItem();
		}

		private void previousItem()
		{
			listboxHelper.selectPreviousItem();
		}

		public enum SimpleSize { Large, Small };
		public enum SortOrder { SORTED, REVERSESORTED, UNSORTED };

		private ListboxHelper listboxHelper;
		private TextboxHelper textboxHelper;
		private ButtonsHelper buttonsHelper;
	}
}