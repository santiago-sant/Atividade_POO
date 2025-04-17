
using System;
using System.Collections.Generic;

public abstract class Animal
{
    // Propriedades
    public string Nome { get; set; }
    public int Idade { get; set; }

    // Construtor
    public Animal(string nome, int idade)
    {
        // Validação para garantir que a idade não seja negativa
        if (idade < 0)
        {
            throw new ArgumentException("Idade não pode ser negativa.");
        }

        Nome = nome;
        Idade = idade;
    }

    // Método abstrato que será implementado nas classes derivadas
    public abstract void EmitirSom();

    // Método virtual para apresentar o animal, pode ser sobrescrito nas classes derivadas
    public virtual void Apresentar()
    {
        Console.WriteLine($"Nome: {Nome}, Idade: {Idade} anos.");
    }
}

public class Gato : Animal
{
    // Construtor que chama o construtor da classe base
    public Gato(string nome, int idade) : base(nome, idade)
    {
    }

    // Implementação do método abstrato EmitirSom()
    public override void EmitirSom()
    {
        Console.WriteLine("O Gato Mia: Miauu!");
    }

    // Sobrescrever o método Apresentar, se desejado
    public override void Apresentar()
    {
        Console.WriteLine($"Eu sou o Gato {Nome} e tenho {Idade} anos.");
    }
}

public class Cachorro : Animal
{
    // Construtor que chama o construtor da classe base
    public Cachorro(string nome, int idade) : base(nome, idade)
    {
    }

    // Implementação do método abstrato EmitirSom()
    public override void EmitirSom()
    {
        Console.WriteLine("O cachorro late: Au au!");
    }

    // Sobrescrever o método Apresentar, se necessário
    public override void Apresentar()
    {
        Console.WriteLine($"Eu sou o cachorro {Nome} e tenho {Idade} anos.");
    }
}

public class Passaro : Animal
{
    // Construtor que chama o construtor da classe base
    public Passaro(string nome, int idade) : base(nome, idade)
    {
    }

    // Implementação do método abstrato EmitirSom()
    public override void EmitirSom()
    {
        Console.WriteLine("O pássaro canta: Piu piu!");
    }

    // Sobrescrever o método Apresentar, se necessário
    public override void Apresentar()
    {
        Console.WriteLine($"Eu sou o pássaro {Nome} e tenho {Idade} anos.");
    }
}

public class Zoo
{
    // Lista de animais no zoológico
    public List<Animal> Animais { get; set; }

    // Construtor
    public Zoo()
    {
        Animais = new List<Animal>();
    }

    // Adicionar animal ao zoo
    public void AdicionarAnimal(Animal animal)
    {
        Animais.Add(animal);
    }

    // Chamar EmitirSom de todos os animais de forma polimórfica
    public void EmitirSonsDeTodosOsAnimais()
    {
        foreach (var animal in Animais)
        {
            animal.EmitirSom();
        }
    }

    // Apresentar todos os animais
    public void ApresentarTodosOsAnimais()
    {
        foreach (var animal in Animais)
        {
            animal.Apresentar();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Criando o zoológico
        Zoo zoologico = new Zoo();

        try
        {
            // Criando instâncias dos animais
            Animal Gato = new Gato("Remii", 5);
            Animal cachorro = new Cachorro("Rex", 3);
            Animal passaro = new Passaro("Piu", 2);

            // Adicionando animais ao zoológico
            zoologico.AdicionarAnimal(Gato);
            zoologico.AdicionarAnimal(cachorro);
            zoologico.AdicionarAnimal(passaro);

            // Apresentando todos os animais
            zoologico.ApresentarTodosOsAnimais();

            // Emitindo som de todos os animais de forma polimórfica
            zoologico.EmitirSonsDeTodosOsAnimais();
        }
        catch (ArgumentException ex)
        {
            // Caso a idade seja negativa, mostra a mensagem de erro
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}
