namespace Frumpy

open System
open System.Windows.Forms

type Update<'Msg, 'Model> = 'Msg -> 'Model -> 'Model
type Dispatch<'Msg> = 'Msg -> obj -> EventArgs -> unit
type View<'Model, 'Msg> = 'Model -> Dispatch<'Msg> -> Control

type Program<'Msg, 'Model> (initialModel:'Model, view:View<'Model,'Msg>, update:Update<'Msg,'Model>) as form =
    inherit Form ()
    let pump = Event<'Msg * 'Model>()
    let evt = pump.Publish
    let dispatch model msg _ _ = pump.Trigger(msg, model)

    do
        evt.Add(fun (msg, model) ->
            let newModel = update msg model
            let newLayout = view newModel (dispatch newModel)
            form.Controls.Clear()
            form.Controls.Add(newLayout))

        let initialLayout = view initialModel (dispatch initialModel)
        form.Controls.Add(initialLayout)

module Program =
    let create initialModel view update =
        new Program<_,_>(initialModel, view, update) :> Form