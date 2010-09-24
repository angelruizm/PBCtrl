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
		private class ButtonsHelper
		{
			public ButtonsHelper(Button[] buttons)
			{
				this.buttons = buttons;
			}

			public bool useWaitCursor
			{
				get { return buttons[0].UseWaitCursor; }
				set { foreach(Button button in buttons) button.UseWaitCursor = value; }
			}

			public SimpleSize ButtonSize
			{
				get { return size; }
				set { resize(value); }
			}

			public ImageList icons
			{
				set { foreach(Button button in buttons) button.ImageList = value; }
			}

			private void resize(SimpleSize size)
			{
				int dimensions = size == SimpleSize.Large ? dimensionsLarge : dimensionsSmall, factor = buttons.Length;

				foreach(Button button in buttons)
				{
					int horizontalMovement = factor-- * dimensionsDiff;
					button.Location = new Point(size == SimpleSize.Large ? button.Location.X - horizontalMovement : button.Location.X + horizontalMovement, button.Location.Y);
					button.Size = new Size(dimensions, dimensions);
				}

				this.size = size;
			}

			public const int dimensionsLarge = 32;
			public const int dimensionsSmall = 24;
			public const int dimensionsDiff = dimensionsLarge - dimensionsSmall;

			private Button[] buttons;
			private SimpleSize size = SimpleSize.Small;
		}
	}
}
