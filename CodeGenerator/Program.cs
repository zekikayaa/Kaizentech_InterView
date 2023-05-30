// See https://aka.ms/new-console-template for more information

using CodeGenerator;

Console.WriteLine("Hello, World!");


var codeGenerator = new CodeGeneratorService();

var codeList = codeGenerator.GenerateCode(1001);


foreach (var code in codeList)
{
    var generatorByCodeService = codeGenerator.CheckCode(code);

    if (!generatorByCodeService)
        throw new Exception();
}


var isSystemCode = codeGenerator.CheckCode("2TP23LK");

var isSystemCode2 = codeGenerator.CheckCode("5TR15NGB");

var isSystemCode3 = codeGenerator.CheckCode("5TR15NGX");


Console.ReadKey();