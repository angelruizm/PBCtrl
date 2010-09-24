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
using System.Drawing;
using System.Windows.Forms;

namespace PB
{
	partial class EditableListBox
	{
		private class ListboxHelper
		{
			public ListboxHelper(ListBox listbox)
			{
				this.listbox = listbox;
			}

			public bool useWaitCursor
			{
				get { return listbox.UseWaitCursor; }
				set { listbox.UseWaitCursor = value; }
			}

			public bool horizontalScroll
			{
				get { return listbox.HorizontalScrollbar; }
				set { listbox.HorizontalScrollbar = value; }
			}

			public int horizontalExtent
			{
				get { return listbox.HorizontalExtent; }
				set { listbox.HorizontalExtent = value; }
			}

			public bool alwaysShowScroll
			{
				get { return listbox.ScrollAlwaysVisible; }
				set { listbox.ScrollAlwaysVisible = value; }
			}

			public bool multiColumn
			{
				get { return listbox.MultiColumn; }
				set { listbox.MultiColumn = value; }
			}

			public int columnWidth
			{
				get { return listbox.ColumnWidth; }
				set { listbox.ColumnWidth = value; }
			}

			public bool showTabs
			{
				get { return listbox.UseTabStops; }
				set { listbox.UseTabStops = value; }
			}

			public bool isSorted
			{
				get { return sortOrder == SortOrder.SORTED || sortOrder == SortOrder.REVERSESORTED; }
				set
				{
					// TODO: This implementation is wrong. Presumably we should really be storing the unsorted order then return to that?
					sortOrder = SortOrder.UNSORTED;
					if(value)
						sort();
				}
			}

			public SortOrder order
			{
				get { return sortOrder; }
			}

			public ListBox.ObjectCollection items
			{
				get { return listbox.Items; }
			}

			public int selectedIndex
			{
				get { return listbox.SelectedIndex; }
				set { listbox.SelectedIndex = value; }
			}

			public void selectItem(Point point)
			{
				if(itemsExist)
					ensureSelection(point);
				else
					selectNewItem();
			}

			public Rectangle selectionRectangle
			{
				get
				{
					if(!itemsExist)
						selectNewItem();

					return new Rectangle(clientPosition.X, clientPosition.Y, listbox.ClientSize.Width, listbox.GetItemRectangle(listbox.SelectedIndex).Height);
				}
			}

			public bool isEmpty
			{
				get { return listbox.Items.Count == 0; }
			}

			public Point location
			{
				get { return listbox.Location; }
			}

			private Point clientPosition
			{
				get { return new Point((listbox.Size.Width - listbox.ClientSize.Width) / 2, listbox.GetItemRectangle(listbox.SelectedIndex).Y + (listbox.Size.Height - listbox.ClientSize.Height) / 2); }
			}

			public void updateSelectedItem(string content)
			{
				if(selectedItem != content)
				{
					selectedItem = content;
					maintainSortOrder();
				}
			}

			public void selectNextItem()
			{
				if(lastItemIsSelected)
				{
					if(lastItemIsPopulated)
						selectNewItem();
					else
						selectFirstItem();
				}
				else
					++listbox.SelectedIndex;
			}

			public void selectPreviousItem()
			{
				if(firstItemIsSelected)
				{
					if(lastItemIsPopulated)
						selectNewItem();
					else
						selectLastItem();
				}
				else
					--listbox.SelectedIndex;
			}

			public void sort()
			{
				switch(sortOrder)
				{
					case SortOrder.UNSORTED:
					case SortOrder.REVERSESORTED:
						sortOrder = SortOrder.SORTED;
						break;

					case SortOrder.SORTED:
						sortOrder = SortOrder.REVERSESORTED;
						break;
				}

				ListBox.ObjectCollection sortedItems = quicksort(listbox.Items);
				listbox.Items.Clear();
				listbox.Items.AddRange(sortedItems);
			}

			public string selectedItem
			{
				get { return (string)listbox.Items[listbox.SelectedIndex]; }
				set { listbox.Items[listbox.SelectedIndex] = value; }
			}

			public void reduceHeight(int difference)
			{
				listbox.Location = new Point(listbox.Location.X, listbox.Location.Y + difference);
				resetHeight();
			}

			public void increaseHeight(int difference)
			{
				listbox.Location = new Point(listbox.Location.X, listbox.Location.Y - difference);
				resetHeight();
			}

			public void raiseSelectedItem()
			{
				if(hasMultipleItems && listbox.SelectedIndex > 0)
				{
					bubbleUpOnce();
					sortOrder = SortOrder.UNSORTED;
				}
			}

			public void lowerSelectedItem()
			{
				if(hasMultipleItems && listbox.SelectedIndex < lastIndex)
				{
					bubbleDownOnce();
					sortOrder = SortOrder.UNSORTED;
				}
			}

			public void addNewItem()
			{
				if(lastItemIsPopulated)
					addItem();

				selectLastItem();
			}

			public void removeItem()
			{
				if(itemsExist && listbox.SelectedIndex >= 0)
				{
					int oldIndex = listbox.SelectedIndex;

					listbox.Items.RemoveAt(listbox.SelectedIndex);

					if(isValidIndex(oldIndex))
						listbox.SelectedIndex = oldIndex;
					else if(itemsExist)
						listbox.SelectedIndex = oldIndex - 1;
				}
			}

			public void focus()
			{
				listbox.Focus();
			}

			private bool itemsExist
			{
				get { return listbox.Items.Count > 0; }
			}

			private bool hasMultipleItems
			{
				get { return listbox.Items.Count > 1; }
			}

			private void ensureSelection(Point point)
			{
				if(noItemsSelected || isOutsideSelection(point))
				{
					if(lastItemIsPopulated && isOutsideSelection(point))
						addItem();

					selectLastItem();
				}
			}

			private bool noItemsSelected
			{
				get { return listbox.SelectedIndex < 0; }
			}

			private bool isOutsideSelection(Point point)
			{
				return noItemsSelected || !selectionRectangle.Contains(point);
			}

			private void selectFirstItem()
			{
				listbox.SelectedIndex = 0;
			}

			private bool firstItemIsSelected
			{
				get { return listbox.SelectedIndex == 0; }
			}

			private void selectLastItem()
			{
				listbox.SelectedIndex = lastIndex;
			}

			private bool lastItemIsSelected
			{
				get { return listbox.SelectedIndex == lastIndex; }
			}

			private bool lastItemIsPopulated
			{
				get { return (string)listbox.Items[lastIndex] != ""; }
			}

			private int lastIndex
			{
				get { return listbox.Items.Count - 1; }
			}

			private void selectNewItem()
			{
				addItem();
				selectLastItem();
			}

			private void addItem()
			{
				listbox.Items.Add("");
			}

			private ListBox.ObjectCollection quicksort(ListBox.ObjectCollection list)
			{
				ListBox.ObjectCollection sorted = new ListBox.ObjectCollection(new ListBox());
				sorted.AddRange(list);

				if(sorted.Count <= 1)
					return sorted;

				int random = randomNumberGenerator.Next(0, sorted.Count - 1);

				string pivot = (string)list[random];
				sorted.RemoveAt(random);

				ListBox.ObjectCollection lessThan = new ListBox.ObjectCollection(new ListBox());
				ListBox.ObjectCollection greaterThan = new ListBox.ObjectCollection(new ListBox());

				for(int i = 0; i < sorted.Count; ++i)
					sortItem(sorted[i], pivot, lessThan, greaterThan);

				sorted = quicksort(lessThan);
				sorted.Add(pivot);
				sorted.AddRange(quicksort(greaterThan));

				return sorted;
			}

			private void sortItem(object item, string comparisonItem, ListBox.ObjectCollection lesserItems, ListBox.ObjectCollection greaterItems)
			{
				if(String.Compare((string)item, comparisonItem, true) < 0)
					addLesserItem(item, lesserItems, greaterItems);
				else
					addGreaterItem(item, lesserItems, greaterItems);
			}

			private void addLesserItem(object lesserItem, ListBox.ObjectCollection lesserItems, ListBox.ObjectCollection greaterItems)
			{
				addSortedItem(lesserItem, lesserItems, greaterItems);
			}

			private void addGreaterItem(object greaterItem, ListBox.ObjectCollection lesserItems, ListBox.ObjectCollection greaterItems)
			{
				addSortedItem(greaterItem, greaterItems, lesserItems);
			}

			private void addSortedItem(object item, ListBox.ObjectCollection sorted, ListBox.ObjectCollection reverseSorted)
			{
				if(sortOrder == SortOrder.SORTED)
					sorted.Add(item);
				else
					reverseSorted.Add(item);
			}

			private void maintainSortOrder()
			{
				if(sortOrder != SortOrder.UNSORTED && hasMultipleItems)
					bubble();
			}

			private void bubble()
			{
				if(shouldBubbleUp)
					bubbleUp();
				else if(shouldBubbleDown)
					bubbleDown();
			}

			private void bubbleUp()
			{
				while(listbox.SelectedIndex != 0 && shouldBubbleUp)
					bubbleUpOnce();
			}

			private void bubbleDown()
			{
				while(listbox.SelectedIndex != lastIndex && shouldBubbleDown)
					bubbleDownOnce();
			}

			private bool shouldBubbleUp
			{
				get
				{
					if(!isValidIndex(bubbleUpIndex))
						return false;
					
					if(sortOrder == SortOrder.SORTED)
						return shouldBeBefore(listbox.SelectedIndex, bubbleUpIndex);

					return shouldBeAfter(listbox.SelectedIndex, bubbleUpIndex);
				 }
			}

			private bool shouldBubbleDown
			{
				get
				{
					if(!isValidIndex(bubbleDownIndex))
						return false;

					if(sortOrder == SortOrder.SORTED)
						return shouldBeAfter(listbox.SelectedIndex, bubbleDownIndex);

					return shouldBeBefore(listbox.SelectedIndex, bubbleDownIndex);
				}
			}

			private int bubbleUpIndex
			{
				get { return listbox.SelectedIndex - 1; }
			}

			private int bubbleDownIndex
			{
				get { return listbox.SelectedIndex + 1; }
			}

			private bool shouldBeBefore(int originIndex, int targetIndex)
			{
				return String.Compare((string)listbox.Items[originIndex], (string)listbox.Items[targetIndex]) < 0;
			}

			private bool shouldBeAfter(int originIndex, int targetIndex)
			{
				return String.Compare((string)listbox.Items[originIndex], (string)listbox.Items[targetIndex]) > 0;
			}

			private bool isValidIndex(int index)
			{
				return index >= 0 && index < listbox.Items.Count;
			}

			private void bubbleUpOnce()
			{
				bubbleOnce(listbox.SelectedIndex, listbox.SelectedIndex - 1);
			}

			private void bubbleDownOnce()
			{
				bubbleOnce(listbox.SelectedIndex, listbox.SelectedIndex + 1);
			}

			private void bubbleOnce(int originIndex, int targetIndex)
			{
				object item = listbox.Items[originIndex];
				listbox.Items[originIndex] = listbox.Items[targetIndex];
				listbox.Items[targetIndex] = item;

				listbox.SelectedIndex = targetIndex;
			}

			private void resetHeight()
			{
				listbox.Height = listbox.Parent.ClientSize.Height - listbox.Location.Y;
			}

			private ListBox listbox;
			private Random randomNumberGenerator = new Random();
			private SortOrder sortOrder = SortOrder.UNSORTED;
		}
	}
}
