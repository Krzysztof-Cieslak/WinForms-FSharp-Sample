// Learn more about F# at http://fsharp.org

open System.Windows.Forms
open MyForms

[<EntryPoint>]
let main argv =
    Application.SetHighDpiMode HighDpiMode.SystemAware |> ignore
    Application.EnableVisualStyles ()
    Application.SetCompatibleTextRenderingDefault false

    let main = App.main
    // Set additional form properties
    main.AutoScaleMode <- AutoScaleMode.Font
    main.ClientSize <- System.Drawing.Size(800, 450)
    main.Text <- "Frumpy"
    // Run the application
    Application.Run main
    0 // return an integer exit code
