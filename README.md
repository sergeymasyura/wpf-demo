# wpf-demo

Color Mixer
Programming Assignment

1. Source code, solution and project files, insctructions to compile:

Source code is in the .\src folder.
The app is the WPF application with .Net 4.7.

2. Compiled executable:
.\exe folder contains application executable. Run the ColorMixer.exe.

3. List of 3rd party dependencies:
Xceed.Wpf.AvalonDock - docking component.
Xceed.Wpf.AvalonDock.Themes.VS2010 - theming for the docking.
Xceed.Wpf.Toolkit - PropertyGrid, Color Editor.
Northwoods.GoWPF - Diagram editor.

4. Screenshots of the application:
The screenshots are located in the .\screenshots folder.

5. Brief description of the application:
The application is intended to mix colors and re-use results in the next operations.
Toolbox contains two types of nodes: Color and Operation.
Drag and drop nodes from the toolbox to the central workspace.
Every Color node has one outcoming port, every Operation node has two incoming and one outcoming.
Create link using a mouse. Place the mouse on top of the port (pointer will change to handle), 
press the left button and move the pointer to create a link.
Select nodes to edit its properties (Color for the color node, Mode for the operation node).
To copy the color of any node - select and open context menu with a right mouse click.
Application uses docking panel, so the user can use a layout he prefer.
Diagram editor supports Copy/Paste, deletion of the nodes/link by del keypress, zooming, undo operations.

6. Possible shortcomings, known issues, ideas for further development:
- Serialization/deserialization of the diagram is not implemented, so the user can't save/load diagrams to/from the file.
- Application uses comercial Northwoods.GoWPF, so 'free evaluation' overlay is shown.
- Xceed.Wpf.AvalonDock is free, but ActiproSoftware.Docking provides much better UX.
- Xceed.Wpf.AvalonDock dll has been modified to fix some bugs with the DockWidth of LayoutAnchorablePaneGroup.
- Xceed.Wpf.Toolkit PropertyGrid dll has been modified to don't use BindingFlags.FlattenHierarchy for the selected object.
- Application has no help file, tutorial.
- Application does not provide channels to report feedback/bug.
- Application does not support updates, so wyUpdate would be useful.
- It would be nice to use multi-tabbed mdi documents, so the user can edit multiple documents at the same time.
- It seems the Undo manager supports only operations with nodes/link, so if for i.e.the user changed a color, he can't undo it.
- Export the diagram to the image also would be useful.
- Unit tests are not implemented.
- The application may need to remember its startup position, sizes.
- The layout of the docking panels may need to be saved/loaded to support better UX.
- The performance of the realtime color mixing with huge graphs (> 1000 nodes) may require some optimizations.
- Grouping of the nodes on the diagram may be useful.
- The application may need a faster way to import colors (now you have to switch to advanced color editor and paste the color code via the keyboard).
- Context menus on the nodes may be extended to include more menu items like Copy, Paste, Delete.
- Depending on the more detailed requirements and use-cases, of course, the application can be easily extended/improved.

Regards,
Sergey Masyura
