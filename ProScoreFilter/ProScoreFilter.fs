namespace ProScoreFilter

type Gymnasts = FSharp.Data.CsvProvider<"gymnasts_sample.csv">

type FileFilter(inputFile: string, outputFile: string) = 
    member this.InputFile = inputFile
    member this.OutputFile = outputFile

    member this.FilterForSession session : bool = 
        let gymnasts = Gymnasts.Load(this.InputFile)
        let filtered = gymnasts.Filter(fun x -> x.Session = session)
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