﻿using ConsoleApp;
using EmployeeDemo;
using ExtensionMethodsDemo;
using Utilities;

namespace MethodsDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Employee dave = new Employee(1, "Dave", "Smith", 30);
            // dave.Print();
            // dave.DoubleTheAge();
            // dave.Print();

            ValueAndRef vr = new ValueAndRef();
            vr.valueAndRef();
            BoxingUnboxing bu = new BoxingUnboxing();
            bu.BoxingUnboxingDemo();
            Student alice = new Student("Alice", 20);
            alice.Print();

            alice.DoubleTheAge();   
            alice.Print();

            alice.MultiplyAge(3);   
            alice.Print();

            Console.WriteLine("Sum: "+ add(5, 10));
        }
        
        public static int add(int x, int y)=> x+y;

        // static void StudentDemo()
        // {
        //     var alice = new Student("Alice", 20);
        //     alice.Print();

        //     var bob = new Student("Bob", 22);
        //     bob.Print();

        //     var dave = new Student("Dave", 24);
        //     dave.Print();

        //     var charlie = new Student("Charlie", 26);
        //     charlie.Print();


        // }
    }



    // class ParametersDemo
    // {
    //     public void Configure(int timeout = 30, bool verbose = false)
    //     {
    //         Console.WriteLine($"Timeout set to: {timeout} seconds");
    //         Console.WriteLine($"Verbose mode: {verbose}");

    //     }

    //     public void SetCount(out int count)
    //     {
    //         // database
    //         // api
    //         count = 42;
    //     }


    //     public int ParamsDemo(params int[] numbers)
    //     {
    //         // syntax sugar
    //         var sum = 0;

    //         foreach (var number in numbers)
    //         {
    //             sum += number;
    //         }

    //         return sum;
    //     }

    //     class Logger
    //     {

    //         public void Log(string message) { }

    //         public int Log(int message) { return 0; }

    //     }
    // }

    // class Student
    // {
    //     public static int NumberOfStudents = 0;
    //     public string Name { get; set; }
    //     public int Age { get; set; }

    //     public Student(string Name, int Age)
    //     {
    //         this.Name = Name;
    //         this.Age = Age;
    //         NumberOfStudents++;
    //     }

    //     // public void Print(Student this)
    //     public void Print()
    //     {
    //         Console.WriteLine($"Name: {this.Name}, Age: {this.Age} Student Count: {NumberOfStudents}");
    //     }

    //     // memory dump
    //     // Dump Analyzer
    //     public int DoubleTheAge(int muyltipBy = 2)
    //     {
    //         return this.Age * muyltipBy;
    //     }

    // }

    // class Calculator
    // {
    //     public int a { get; set; }
    //     public int b { get; set; }

    //     public Calculator(int a, int b)
    //     {
    //         this.a = a;
    //         this.b = b;
    //     }

    //     public int Add()
    //     {
    //         return this.a + this.b;
    //     }

    //     public static int Add(int a, int b)
    //     {
    //         return a + b;
    //     }
    // }


    
}