# PB Controls

This repository contains a library of .NET user controls that I'm
gradually building up as I work on other projects. Currently, there
are two controls in the library: EditableListBox and HTMLRenderer.

## EditableListBox

EditableListBox is intended to be an intuitive, editable ListBox
control.

Edit mode is accessed by double-clicking on the control or pressing
Enter when an item is selected. Once you're in edit mode, the up and
down cursor keys can be used to cycle through the different items
without committing any changes that are made. Tab and Shift+Tab can
be used to cycle through the items, committing any changes that are
made as you go along. Pressing Enter will commit changes and leave
edit mode. Pressing Esc or simply navigating away from the edit
region will leave edit mode without committing changes.

Programmatic interaction with the listed items is done through the
public `Items` property. The programming interface is modelled on
that exposed by the .NET ListBox control from System.Windows.Forms.

## HTMLRenderer

HTMLRenderer is an HTML+CSS document renderer. Because it is simply
a wrapper for the native WebBrowser control, it falls prey to the
vagaries of the version of Internet Explorer that happens to be
installed on the end user's machine.

Three methods are provided for rendering documents:

  * `void RenderURL(string)` renders the document located at the
    supplied URL.
  * `void RenderFile(string)` renders the document located at the
    supplied local file path (UNC paths are not supported).
  * `void RenderMarkup(string)` renders the document markup as
    supplied in the argument.

In addition, two methods are provided to support communication
between the rendered document and the hosting application:

  * `object CallFunction(string, object[])`: Calls the script
    function specified by the first argument, passing the second
    argument as arguments and returning any return value.
  * `void AddCallback(Object)`: Adds the supplied object to the
    rendered DOM as window.external.

