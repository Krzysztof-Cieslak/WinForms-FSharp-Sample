namespace MyForms

open System.Windows.Forms

type Form1 () as self =
    inherit Form ()

    do self.InitializeComponent()

    member private self.InitializeComponent () =
        base.AutoScaleMode <- AutoScaleMode.Font
        base.ClientSize <- System.Drawing.Size(800, 450)
        base.Text <- "Form 1"
        ()