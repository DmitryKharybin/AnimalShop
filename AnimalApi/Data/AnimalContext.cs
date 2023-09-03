using AnimalApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimalApi.Data
{
    public class AnimalContext : DbContext
    {
        public AnimalContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Category>().HasData(
                new
                {
                    CategoryId = 1,
                    Name = "Bird"
                },
                 new
                 {
                     CategoryId = 2,
                     Name = "Mammal"
                 },
                  new
                  {
                      CategoryId = 3,
                      Name = "Reptile"
                  },
                   new
                   {
                       CategoryId = 4,
                       Name = "Fish"
                   },
                    new
                    {
                        CategoryId = 5,
                        Name = "Amphibian"
                    }
                );



            modelBuilder.Entity<Animal>().HasData(
              new
              {
                  AnimalId = 1,
                  Name = "Eagle",
                  PictureName = "Eagle.jpg",
                  Age = 10,
                  Description = "Eagle is the common name for many large birds of prey of the family Accipitridae." +
                  " Eagles belong to several groups of genera, some of which are closely related." +
                  " Most of the 68 species of eagles are from Eurasia and Africa",
                  CategoryId = 1
              },
               new
               {
                   AnimalId = 2,
                   Name = "Quokka",
                   PictureName = "Quokka.jpg",
                   Age = 6,
                   Description = "The quokka is a small macropod about the size of a domestic cat." +
                   " It is the only member of the genus Setonix. Like other marsupials in the macropod" +
                   " family, the quokka is herbivorous and mainly nocturnal",
                   CategoryId = 2
               },
               new
               {
                   AnimalId = 3,
                   Name = "Wombat",
                   PictureName = "Wombat.jpg",
                   Age = 14,
                   Description = "Wombats are short-legged, muscular quadrupedal marsupials that are native to Australia." +
                   " They are about 1 m (40 in) in length with small, stubby tails and weigh between 20 and 35 kg (44 and 77 lb).",

                   CategoryId = 2
               },
               new
               {
                   AnimalId = 4,
                   Name = "Tasmanian Devil",
                   PictureName = "TasmanianDevil.jpg",
                   Age = 15,
                   Description = "The Tasmanian devil" +
                   " is a carnivorous marsupial of the family Dasyuridae. Until recently, it was only found on the island state of Tasmania," +
                   " but it has been reintroduced to New South Wales in mainland Australia, with a small breeding population.",
                   CategoryId = 2
               },
               new
               {
                   AnimalId = 5,
                   Name = "Fox",
                   PictureName = "Fox.jpg",
                   Age = 13,
                   Description = "Foxes are small to medium-sized, omnivorous mammals belonging to several genera of the family Canidae." +
                   " They have a flattened skull, upright, triangular ears, a pointed, slightly upturned snout, and a long bushy tail.",
                   CategoryId = 2
               },
               new
               {
                   AnimalId = 6,
                   Name = "Llama",
                   PictureName = "Llama.jpg",
                   Age = 22,
                   Description = "The llama is a domesticated South American camelid," +
                   " widely used as a meat and pack animal by Andean cultures since the Pre-Columbian era.",
                   CategoryId = 2
               },
               new
               {
                   AnimalId = 7,
                   Name = "Lemur",
                   PictureName = "Lemur.jpg",
                   Age = 19,
                   Description = "Lemurs are wet-nosed primates of the superfamily " +
                   "Lemuroidea divided into 8 families and consisting of 15 genera and around 100 existing species." +
                   " They are endemic to the island of Madagascar. Most existing lemurs are small, have a pointed" +
                   " snout, large eyes, and a long tail. They chiefly live in trees and are active at night.",
                   CategoryId = 2
               },
               new
               {
                   AnimalId = 8,
                   Name = "Whale",
                   PictureName = "Whale.png",
                   Age = 32,
                   Description = "Whales are a widely distributed and diverse group of fully aquatic placental marine mammals." +
                   " As an informal and colloquial grouping, they correspond to large members of the infraorder Cetacea, i.e. all cetaceans apart from dolphins and porpoises." +
                   " Dolphins and porpoises may be considered whales from a formal, cladistic perspective.",
                   CategoryId = 2
               },
               new
               {
                   AnimalId = 9,
                   Name = "Parrot",
                   PictureName = "Parrot.jpg",
                   Age = 6,
                   Description = "a tropical bird with a curved beak and usually colorful feathers, some of which can be taught to repeat words",
                   CategoryId = 1
               }
              );


            modelBuilder.Entity<Comment>().HasData(
            new
            {
                CommentId = 1,
                AnimalId = 1,
                Note = "Great Animal"
            },
             new
             {
                 CommentId = 2,
                 AnimalId = 1,
                 Note = "10/10 would recommend"
             },
              new
              {
                  CommentId = 3,
                  AnimalId = 2,
                  Note = "Fascinating creature "
              },
               new
               {
                   CommentId = 4,
                   AnimalId = 2,
                   Note = "It's so happy"
               },
               new
               {
                   CommentId = 5,
                   AnimalId = 3,
                   Note = "I love the region They are from"
               },
               new
               {
                   CommentId = 6,
                   AnimalId = 4,
                   Note = "I heard there is a cartoon about this animal"
               },
               new
               {
                   CommentId = 7,
                   AnimalId = 5,
                   Note = "What does it say"
               },
               new
               {
                   CommentId = 8,
                   AnimalId = 6,
                   Note = "Wow , my favorite animal"
               },
               new
               {
                   CommentId = 9,
                   AnimalId = 7,
                   Note = "It reminds me of the Llemur in my local zoo , he's name is julian"
               },
               new
               {
                   CommentId = 10,
                   AnimalId = 8,
                   Note = "The largest Animal in the ocean"
               },
               new
               {
                   CommentId = 11,
                   AnimalId = 9,
                   Note = "I wonder if this parrot can talk"
               }
              );

        }
    }
}
