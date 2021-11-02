using System;

namespace formatif2_sol
{
    class Program
    {
        static void Main(string[] args)
        {
            // Tableau arbitraire pour les prix d'essence
            double[] tabPrixEssence = { 1.499, 0.999, 1.179, 1.397, 1.459 };
            double moyennePrixEssence = 0.0;
            int frequencePrixInferieur = 0;

            // Tests pour les questions 1 à 3
            AfficherTableMultiplication(12);
            Console.ReadKey();
            Console.Clear();

            AfficherToutesTablesImbrique(5);
            Console.ReadKey();
            Console.Clear();

            AfficherToutesTablesMethode(5);
            Console.ReadKey();
            Console.Clear();

            moyennePrixEssence = CalculerMoyenne(tabPrixEssence);
            Console.WriteLine($"Prix moyen essence : {moyennePrixEssence}");
            frequencePrixInferieur = CalculerFrequencePrixInferieur(tabPrixEssence);
            Console.WriteLine($"Fréquence des prix inférieurs : {frequencePrixInferieur}");
            Console.ReadKey();
            Console.Clear();

            //Question 4
            // 4.1
            int nbEtudiant = 0;
            int nbEchec = 0;
            double moyenneGroupe = 0.0;
            int note = 1;
            Console.WriteLine("Entrer les résultats, résultat négatif pour arrêter");
            while (note >= 0)
            {
                // 4.2
                // Remplacer les 2 prochaine ligne par la méthode de saisie
                //Console.WriteLine("Entrer une note :");
                //int.TryParse(Console.ReadLine(), out note);
                note = SaisirNote();
                if (note >= 0)
                {
                    nbEtudiant++;
                    if (note < 60)
                    {
                        nbEchec++;
                    }
                }
                moyenneGroupe += note;
            }
            if (nbEtudiant > 0)
            {
                moyenneGroupe /= nbEtudiant;
            }
            else
            {
                moyenneGroupe = 0;
            }

            Console.WriteLine($"Nb étudiants : {nbEtudiant} -- moyenne : {moyenneGroupe} -- nb échecs : {nbEchec}");
            Console.ReadKey();
            Console.Clear();
        }
        /*
        * Afficher la table de multiplication de 1 à 12 pour un nombre entier donné 
        * 
        * @param nombre le nombre entier pour lequel on affiche  
        * la table de multiplication 
        */
        static void AfficherTableMultiplication(int nombre)
        {
            Console.WriteLine($"Table de multiplication pour le nombre {nombre}");
            // boucle qui va de 1 à 12
            for (int i = 1; i < 13; i++)
            {
                Console.WriteLine($"{nombre} x {i} = {nombre * i}");
            }
        }
        /* 
        * Afficher toutes les tables de multiplication, de 1 à 12, à partir 
        * de 1 jusqu’au nombre passé en paramètre 
        * 
        * Cette version utilise une boucle impriquée
        * 
        * @param nombre le dernier nombre pour lequel on affiche la table 
        */
        static void AfficherToutesTablesImbrique(int nombre)
        {
            Console.WriteLine($"Tables de multiplication de 1 à {nombre}");
            //Boucle qui commence à 1 et finit au nombre passé en paramètre
            for (int i = 1; i <= nombre; i++)
            {
                // Même logique que pour le numéro 1 mais on utilise i pour
                // les tables de multiplication
                Console.WriteLine($"Table de multiplication pour le nombre {i}");
                for (int j = 1; j < 13; j++)
                {
                    Console.WriteLine($"{i} x {j} = {i * j}");
                }
            }
        }
        /* 
        * Afficher toutes les tables de multiplication, de 1 à 12, à partir 
        * de 1 jusqu’au nombre passé en paramètre 
        * 
        * Cette version utilise la méthode de la question 1 pour simplifier la tâche
        * 
        * @param nombre le dernier nombre pour lequel on affiche la table 
        */
        static void AfficherToutesTablesMethode(int nombre)
        {
            Console.WriteLine($"Tables de multiplication de 1 à {nombre}");
            //Boucle qui commence à 1 et finit au nombre passé en paramètre
            for (int i = 1; i <= nombre; i++)
            {
                AfficherTableMultiplication(i);
            }
        }
        /* 
        * Calculer et retourner le prix moyen de l’essence pour une période
        *
        * @param tabPrixEssence un tableau des prix d’essence
        * @return le prix moyen de l’essence
        */
        static double CalculerMoyenne(double[] tabPrixEssence)
        {
            double moyenne = 0;
            foreach (double prix in tabPrixEssence)
            {
                moyenne += prix;
            }

            moyenne /= tabPrixEssence.Length;

            return moyenne;
        }
        /*
        * Trouver le nombre de fois où le prix de l'essence a été sous la moyenne
        *
        * @param tabPrixEssence un tableau des prix d'essence
        * @return le nombre de fois où le prix a été inférieur à la moyenne
        */
        static int CalculerFrequencePrixInferieur(double[] tabPrixEssence)
        {
            double moyenne = CalculerMoyenne(tabPrixEssence);
            int frequence = 0;
            for (int i = 0; i < tabPrixEssence.Length; i++)
            {
                if (tabPrixEssence[i] < moyenne)
                {
                    frequence++;
                }
            }
            return frequence;
        }
        /*
        * Saisir une note entière plus petite que 101
        *
        * @return une note entière plus petite que 101
        */
        static int SaisirNote()
        {
            int note = 0;
            bool continuer = true;
            bool noteValide = false;
            while (continuer)
            {
                Console.WriteLine("Entrer une note :");
                noteValide = int.TryParse(Console.ReadLine(), out note);
                if (noteValide)
                {
                    if (note > 100)
                    {
                        Console.WriteLine("Le résultat saisi doit être inférieur ou égal à 100");
                    }
                    else
                    {
                        continuer = false;
                    }
                }
                else
                {
                    Console.WriteLine("Le résultat saisi est invalide, recommencez!");
                }
            }
            return note;
        }
    }
}
