namespace TextCleanerTest
module TextCleanerTest =
    open NUnit.Framework
    open TextCleaner.textCleaner
    open FsCheck

    [<SetUp>]
    let testString = "This is a test string"
      
    [<Test>]
    let ``fullParse converts tab characters to spaces`` () =
        let testString1 = fullParse "This is a test\tstring"
        Assert.AreEqual(testString,testString1)
    
    [<Test>]
    let ``fullParse converts tabs to spaces`` () =
        let testString2 = fullParse "This is a test  string"
        Assert.AreEqual(testString,testString2)
    
    [<Test>]
    let ``fullParse removes newline characters`` () =
        let testString3 = fullParse "This is a test\n string"
        Assert.AreEqual(testString,testString3)
    
    [<Test>]
    let ``fullParse removes carriage return characters`` () =
        let testString4 = fullParse "This is a test\r string"
        Assert.AreEqual(testString,testString4)

    [<Test>]
    let ``fullParse converts multiple spaces to a single space`` () =
        let testString5 = fullParse "This is a test          string"
        Assert.AreEqual(testString,testString5)
    
    [<Test>]
    let ``fullParse converts both tab characters and tabs in the same string`` () =
        let testString6 = fullParse "This\tis a test   string"
        Assert.AreEqual(testString,testString6)
    
    [<Test>]
    let ``fullParse converts tab characters to spaces and removes newline characters in the same string`` () =
        let testString7 = fullParse "This\tis a test\n string"
        Assert.AreEqual(testString,testString7)
    
    [<Test>]
    let ``fullParse converts tab characters to spaces and removes carriage return characters in the same string`` () =
        let testString8 = fullParse "This\tis a test\r string"
        Assert.AreEqual(testString,testString8)

    [<Test>]
    let ``fullParse convers tab characters to spaces and removes quotes in the same string`` () =
        let testString9 = fullParse "This is\ta test\" string"
        Assert.AreEqual(testString,testString9)
    
    [<Test>]
    let ``fullParse converts tab characters and multiple spaces to single spaces in the same string`` () =
        let testString10 = fullParse "This        is a test\tstring"
        Assert.AreEqual(testString,testString10)
    
    [<Test>]
    let ``fullParse converts tabs to spaces and removes newline characters in the same string`` () =
        let testString11 = fullParse "This  is a test\n string"
        Assert.AreEqual(testString,testString11)
    
    [<Test>]
    let ``fullParse converts tabs to spaces and removes carriage return characters in the same string`` () =
        let testString12 = fullParse "This  is a test\r string"
        Assert.AreEqual(testString,testString12)
    
    [<Test>]
    let ``fullParse converts tabs to spaces and removes quotes in the same string`` () =
        let testString13 = fullParse "This is   a test str\"ing"
        Assert.AreEqual(testString,testString13)
    
    [<Test>]
    let ``fullParse converts tabs to spaces and multiple spaces to a single space in the same string`` () =
        let testString14 = fullParse "This  is a test                      string"
        Assert.AreEqual(testString,testString14)
    
    [<Test>]
    let ``fullParse removes newline characters and carriage return characters in the same string`` () =
        let testString15 = fullParse "This is\n a\r test\r stri\nng"
        Assert.AreEqual(testString,testString15)
    
    [<Test>]
    let ``fullParse removes newline characters and removes quotes in the same string`` () =
        let testString16 = fullParse "Th\nis is a\" test st\"ring"
        Assert.AreEqual(testString,testString16)
    
    [<Test>]
    let ``fullParse removes newline characters and converts multiple spaces to a single space in the same string`` () =
        let testString17 = fullParse "This\n is a              test string"
        Assert.AreEqual(testString,testString17)
    
    [<Test>]
    let ``fullParse removes carriage return characters and quotes in the same string`` () =
        let testString18 = fullParse "This is a\r test\" st\"ring"
        Assert.AreEqual(testString,testString18)
    
    [<Test>]
    let ``fullParse removes carriage return characters and converts multiple spaces to a single space in the same string`` () =
        let testString19 = fullParse "This\r     is a test     string\r"
        Assert.AreEqual(testString,testString19)
    
    [<Test>]
    let ``fullParse removes quotes and converts multiple spaces to a single space in the same string`` () =
        let testString20 = fullParse "This is\" a test\"           string"
        Assert.AreEqual(testString,testString20)
    
    [<Test>]
    let ``fullParse completely strips everything out of a string which is not needed in the SpamFilter`` () =
        let testString21 = fullParse "T\nh\ris    is      a\t test  str\"ing"
        Assert.AreEqual(testString,testString21)