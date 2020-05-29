namespace MyForms

module App =
    open System
    open System.Windows.Forms
    open Frumpy

    type Model = int
    let initialModel : Model = 0

    type Msg = Increment | Decrement
    let update msg model =
        match msg with
        | Increment -> model + 1
        | Decrement -> model - 1

    let view model dispatch =
        let clickCount = new Label(Text=sprintf "Clicked %d times" model)

        let incrButton = new Button(Text="+")
        let incrClickHandler = EventHandler(dispatch Increment)
        incrButton.Click.AddHandler(incrClickHandler)

        let decrButton = new Button(Text="-")
        let decrClickHandler = EventHandler(dispatch Decrement)
        decrButton.Click.AddHandler(decrClickHandler)

        let layout = new FlowLayoutPanel(Dock=DockStyle.Fill)
        layout.Controls.Add(clickCount)
        layout.Controls.Add(incrButton)
        layout.Controls.Add(decrButton)

        layout :> Control

    // Create the program
    let main = Program.create initialModel view update
