namespace TextCleaner
module textCleaner =

    // Removes tab characters and converts them to a single space
    let tabCharacterToSpace (s : string) =
        s.Replace("\t", " ")

    // Removes tabs and converts them to a single space
    let tabToSpace (s : string) =
        s.Replace("     "," ")

    // Removes instances of multiple spaces and converts them to a singlular space
    let rec singleSpace (s : string) =
        if s.Contains("  ") then
            singleSpace (s.Replace("  ", " "))
        else
            s

    // Removes quatation marks and replaces them with an empty string -- Quotes mess up the spam filter
    let removeQuotes (s : string) =
        s.Replace("\"","")

    // Removes newline characters
    let removeNewLine (s : string) =
        s.Replace("\n","")

    // Removes carriage return characters
    let removeCarriageReturn (s : string) =
        s.Replace("\r","")

    // Combines all stripping functions in to one full parse
    let fullParse str = 
        if str = null
        then
            None
        else
            let strCopy = str
            str
            |> tabCharacterToSpace
            |> tabToSpace
            |> removeNewLine
            |> removeCarriageReturn
            |> removeQuotes 
            |> singleSpace
            |> Some