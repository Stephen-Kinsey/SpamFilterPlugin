namespace TextCleaner
module TextCleaner =
    open System

    /// Strips all html tags out of a string
    let striptags input = 
        let rec get_next_character (flag, text) =
            match flag with
            | _     when (Seq.isEmpty text)    -> None
            | _     when (Seq.head text = '<') -> get_next_character (false,  Seq.tail text) 
            | _     when (Seq.head text = '>') -> get_next_character (true,   Seq.tail text)
            | _     when (Seq.head text = '"') -> get_next_character (true,   Seq.tail text) 
            | false                            -> get_next_character (false,  Seq.tail text) 
            | true                             -> Some (Seq.head text, (true, Seq.tail text)) 
        
        Seq.unfold get_next_character (true, input) 
        |> Seq.toArray 
        |> String 

    /// Removed all tabs and replaces them with a single space
    let tabtospace (s : String) =
        /// takes a string as an input
        s.Replace("\t", " ")
        /// looks through the string and replaces all instances where a \t (tab) is found with a ' ' (space)


    /// Removes instances where there is a space more than once and replaces them with a single space
    let rec singlespace (s : String) =
        /// takes a string as an input
        if s.Contains("  ") then
            singlespace (s.Replace("  ", " "))
        /// checks to see if the string contains "  " (multiple spaces) and replaces them with a " " (single space)
        else
            s
        /// if there are no cases of multiple spaces, return the input

    ///let fullparse = singlespace |> tabtospace |> striptags


    let result = striptags "This text is HTML\" with an \"embeded<img> tag"
    let result1 = tabtospace "hello\tworld!"
    let result2 = singlespace "hello       world!"
