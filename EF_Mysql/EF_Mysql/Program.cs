using MySqlEntityFramework;
using System;
using System.Data.Entity;
using System.Linq;

namespace EF_Mysql
{
    class Program
    {
        static void Main(string[] args)
        {
            //Cadastra();
            //Exibe();
            //RemoverTodos();
            Atualizar();
            Exibe();


            //Remover(new Produto { Id = 5  });
            //removerState();

            Console.ReadKey();
        }

        public static void Cadastra()
        {
            using (var contexto = new DBContext())
            {
                Produto p = new Produto
                {
                    Nome = "Denois",
                    Preco = 40000
                };

                contexto.Produtos.Add(p);
                contexto.SaveChanges();
            }
        }

        public static void Exibe()
        {
            using (var contexto = new DBContext())
            {
                var p = contexto.Produtos;
                
                Console.WriteLine("\nMostrando os produtos...");
                foreach (var item in p)
                {
                    Console.WriteLine($"ID: {item.Id}, Nome:{item.Nome}, Preço:{item.Preco}");
                }
            }
            
        }
                
        public static void Remover(Produto p)
        {
            using (var contexto = new DBContext())
            {                                
                contexto.Produtos.Attach(p);
                contexto.Produtos.Remove(p);
                contexto.SaveChanges();   
            }

            
        }

        public static void removerState()
        {
            using (var contexto = new DBContext())
            {
                var Produtos = new Produto { Id = 8 };
                contexto.Entry(Produtos).State = EntityState.Deleted;
                contexto.SaveChanges();
            }
        }

        public static void RemoverTodos()
        {            
            using (var contexto = new DBContext())
            {
                var p = contexto.Produtos;

                Console.WriteLine("\nRemover todos os produtos...");
                foreach (var item in p)
                {
                    Console.WriteLine($"ID: {item.Id}, Nome:{item.Nome}, Preço:{item.Preco} - [REMOVIDO]" );
                    contexto.Produtos.Remove(item);
                    contexto.SaveChanges();
                }
            }

        }

        public static void Atualizar()
        {
            using (var contexto = new DBContext())
            {
                var p = contexto.Produtos.Where(s => s.Nome == "Denois").First();
                p.Nome = "Anderson Bellini";
                p.Preco = 50;
                contexto.SaveChanges(); 
            }
    
           
            

        }

    }
}
