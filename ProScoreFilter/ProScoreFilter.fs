namespace ProScoreFilter

open System

type Gymnasts = FSharp.Data.CsvProvider<"gymnasts_sample.csv">

type FileFilter(inputFile: string, outputFile: string, includeScratched: bool, includeNotDone: bool) = 
    member this.InputFile = inputFile
    member this.OutputFile = outputFile
    member this.IncludeScratched = includeScratched
    member this.IncludeNotDone = includeNotDone

    member this.FilterForSession session : bool = 
        let gymnasts = Gymnasts.Load(this.InputFile)
        let sessionFiltered = gymnasts.Filter(fun x -> x.Session = session)
        let scratchFiltered = sessionFiltered.Filter(fun g -> (not g.Scratched || true))
        
//        if (IncludeNotDone) then
//            let filtered = scratchFiltered.Filter( fun g -> 
//                not (Double.IsNaN g.E1S1) && not (Double.IsNaN g.E1S2)
//                && not (Double.IsNaN g.E2S1) && not (Double.IsNaN g.E2S2)
//                && not (Double.IsNaN g.E3S1) && not (Double.IsNaN g.E3S2)
//                && not (Double.IsNaN g.E4S1) && not (Double.IsNaN g.E4S2)
//            )
//        else 
//            let filtered = scratchFiltered

        let filtered = scratchFiltered.Filter( fun g -> 
                not (Double.IsNaN g.E1S1) && not (Double.IsNaN g.E1S2)
                && not (Double.IsNaN g.E2S1) && not (Double.IsNaN g.E2S2)
                && not (Double.IsNaN g.E3S1) && not (Double.IsNaN g.E3S2)
                && not (Double.IsNaN g.E4S1) && not (Double.IsNaN g.E4S2)
            )
        let isEmpty = filtered.Rows |> Seq.isEmpty
        if not (isEmpty) then
            filtered.Save(this.OutputFile)
            true
        else false

    member this.FilterForUSAG usag : bool = 
        let gymnasts = Gymnasts.Load(this.InputFile)
        let filtered = gymnasts.Filter(fun x -> x.USAG = usag)
        let isEmpty = filtered.Rows |> Seq.isEmpty
        if not (isEmpty) then
            filtered.Save(this.OutputFile)
            true
        else false

        
    member this.FilterForProScore number : bool = 
        let gymnasts = Gymnasts.Load(this.InputFile)
        let filtered = gymnasts.Filter(fun x -> x.Num = number)
        let isEmpty = filtered.Rows |> Seq.isEmpty
        if not (isEmpty) then
            filtered.Save(this.OutputFile)
            true
        else false


    //private member this.Filter 