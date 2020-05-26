// Learn more about F# at http://fsharp.org

open System
open System.Windows.Forms
open MyForms

[<EntryPoint>]
let main argv =
    Application.SetHighDpiMode(HighDpiMode.SystemAware);
    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);
    Application.Run(new Form1());
    0 // return an integer exit code
