namespace Suave

    module Http =
        type RequestType = GET | POST
        type Request = { 
            Route : string
            Type : RequestType
        }
        type Response = {
            Content : string
            StatusCode : int
        }
        type Context = {
            Request : Request
            Response : Response
        }
        type Webpart = Context -> Async<Context option>

    module Successful =
        open Http

        let OK content context = 
            { context with Response = {Content = content; StatusCode = 200}}
            |> Some
            |> async.Return


    module Console =
        open Http
        let execute inputContext webpart =
            async {
                let! outputContext = webpart inputContext
                match outputContext with
                | Some context ->
                    printfn "--------------"
                    printfn "Code	:	%d" context.Response.StatusCode
                    printfn "Output	:	%s" context.Response.Content
                    printfn "--------------"
                | None -> 
                    printfn "No Output"            
            } |> Async.RunSynchronously