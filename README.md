# Esse é um repositorio que cria outputs e inputs personalizados em CSharp

### No terminal, digite:
```sh
git clone https://github.com/LucasAlanderson/ConsoleExtensions.git
```

## Após isso, você cria um console **.NET**. Para isso, execute o seguinte comando no terminal
```sh
dotnet new console --use-program-main
```

## Se, por algum motivo, esse comando estiver dando erro, tente o comando abaixo
```sh
dotnet new console --use-program-main --force
```

### O `--force` vai servir para forçar a criação de um novo console

## Após tudo isso, provávelmente, seu `Program.cs` — desconsiderando o `namespace` — vai estar assim (vai depender da sua versão do .NET):
```csharp
using System;

class main
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
    }
}
```

## Mude para esse:
```csharp
using System;
using ConsoleExtensions.Scanner;
using ConsoleExtensions.Application;

class main                                           
{
    static void Main(string[] args)
    {
        Scanner scan = new Scanner(InputMode.In);
        Application.run("Digite seu nome: ");
        string nome = scan.nextLine();
        Application.runln("Olá, %s! Muito prazer!", nome);

    }
}
```

## Depois de tudo isso, digite o comando `dotnet run` no terminal... Ou não, vai da sua escolha 
