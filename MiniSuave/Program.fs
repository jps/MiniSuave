module  MiniSuave.Program
open    Suave.Http
open    Suave.Console
open    Suave.Successful

    
    // Learn more about F# at http://fsharp.org
    // See the 'F# Tutorial' project for more help.

    [<EntryPoint>]
    let main argv = 
        let request = {Route = ""; Type = Suave.Http.GET }
        let response = {Content = ""; StatusCode = 200}
        let context = {Request = request; Response = response;}
        
        execute context (OK "Hello Suave!")
        printfn "%A" argv
        0 // return an integer exit code
