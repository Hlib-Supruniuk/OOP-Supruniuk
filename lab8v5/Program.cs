using System;
using System.Collections.Generic;

List<Animal> animals = new List<Animal>
{
    new Lion("Лев", 25),
    new Elephant("Слон", 1.5),
    new Bird("Пташка", 0.3)
};

List<string> sounds = new List<string>();

Console.WriteLine("Звуки тварин:");
Console.WriteLine();

foreach (Animal animal in animals)
{
    animal.MakeSound();
    sounds.Add(animal.Sound);
}