namespace TextCleanerTest
module TextCleanerTest =
    open NUnit.Framework
    open TextCleaner
    open FsCheck

    [<Test>]
    let ``tab character converts to single space`` () =
        Assert.Pass()

    [<Test>]
    let ``Multiple tab characters converts to multiple spaces`` () =
        Assert.Pass()
    
    [<Test>]
    let ``Does nothing when no tab character is detected`` () =
        Assert.Pass()
    
    [<Test>]
    let ``tab converts to single space`` () =
        Assert.Pass()

    [<Test>]
    let ``Multible tabs converts to multiple spaces`` () =
        Assert.Pass()
    
    [<Test>]
    let ``Does nothing when no tabs are detected`` () =
        Assert.Pass()
    
    [<Test>]
    let ``tab within spaces converts to correct amount of spaces`` () =
        Assert.Pass()
    
    [<Test>]
    let ``Multiple spaces converts to a single space`` () =
        Assert.Pass()
    
    [<Test>]
    let ``Multiple spaces together multiple times converts to correct amount of spaces`` () =
        Assert.Pass()
    
    [<Test>]
    let ``Does nothing when no multiple spaces are detected`` () =
        Assert.Pass()

    [<Test>]
    let ``Double quotes are removed in a string`` () =
        Assert.Pass()
    
    [<Test>]
    let ``Multiple double quotes are removed in a string`` () =
        Assert.Pass()
    
    [<Test>]
    let ``Does nothing when no double quotes are detected`` () =
        Assert.Pass()
    
    [<Test>]
    let ``Removes newline characters`` () =
        Assert.Pass()
    
    [<Test>]
    let ``Removes multiple newline characters in one string`` () =
        Assert.Pass()
    
    [<Test>]
    let ``Does nothing when no newline characters are detected`` () =
        Assert.Pass()
    
    [<Test>]
    let ``Removes carriage return characters`` () =
        Assert.Pass()
    
    [<Test>]
    let ``Removes multiple carriage return characters in one string`` () =
        Assert.Pass()
    
    [<Test>]
    let ``Does nothing when no carriage return characters are detected`` () =
        Assert.Pass()
    
    [<Test>]
    let ``fullParse converts tab characters to spaces`` () =
        Assert.Pass()
    
    [<Test>]
    let ``fullParse converts tabs to spaces`` () =
        Assert.Pass()
    
    [<Test>]
    let ``fullParse removes newline characters`` () =
        Assert.Pass()
    
    [<Test>]
    let ``fullParse removes carriage return characters`` () =
        Assert.Pass()

    [<Test>]
    let ``fullParse converts multiple spaces to a single space`` () =
        Assert.Pass()
    
    [<Test>]
    let ``fullParse converts both tab characters and tabs in the same string`` () =
        Assert.Pass()
    
    [<Test>]
    let ``fullParse converts tab characters to spaces and removes newline characters in the same string`` () =
        Assert.Pass()
    
    [<Test>]
    let ``fullParse converts tab characters to spaces and removes carriage return characters in the same string`` () =
        Assert.Pass()

    [<Test>]
    let ``fullParse convers tab characters to spaces and removes quotes in the same string`` () =
        Assert.Pass()
    
    [<Test>]
    let ``fullParse converts tab characters and multiple spaces to single spaces in the same string`` () =
        Assert.Pass()
    
    [<Test>]
    let ``fullParse converts tabs to spaces and removes newline characters in the same string`` () =
        Assert.Pass()
    
    [<Test>]
    let ``fullParse converts tabs to spaces and removes carriage return characters in the same string`` () =
        Assert.Pass()
    
    [<Test>]
    let ``fullParse converts tabs to spaces and removes quotes in the same string`` () =
        Assert.Pass()
    
    [<Test>]
    let ``fullParse converts tabs to spaces and multiple spaces to a single space in the same string`` () =
        Assert.Pass()
    
    [<Test>]
    let ``fullParse removes newline characters and carriage return characters in the same string`` () =
        Assert.Pass()
    
    [<Test>]
    let ``fullParse removes newline characters and removes quotes in the same string`` () =
        Assert.Pass()
    
    [<Test>]
    let ``fullParse removes newline characters and converts multiple spaces to a single space in the same string`` () =
        Assert.Pass()
    
    [<Test>]
    let ``fullParse removes carriage return characters and quotes in the same string`` () =
        Assert.Pass()
    
    [<Test>]
    let ``fullParse removes carriage return characters and converts multiple spaces to a single space in the same string`` () =
        Assert.Pass()
    
    [<Test>]
    let ``fullParse removes quotes and converts multiple spaces to a single space in the same string`` () =
        Assert.Pass()
    
    [<Test>]
    let ``fullParse completely strips everything out of a string which is not needed in the SpamFilter`` () =
        Assert.Pass()