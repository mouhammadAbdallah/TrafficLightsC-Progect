using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Traffic_signs
{

    public class Plan1
    {
        public static int stopVoitureBas ;
        public static int stopVoitureGauche;
        public static int stopVoitureHaut;
        public static int stopVoitureDroite;
        public static int stopPersonBas;
        public static int stopPersonGauche;
        public static int stopPersonHaut;
        public static int stopPersonDroite;
        public static bool capableDeQuite, capableVoitureN,capableVoitureZ;


        public feuxPlan1 fp1;
        public static void annulerVPCree()
        {
            capableDeQuite = false;capableVoitureN = false; capableVoitureZ = false;
            VoiturePlan1.nbVoitureCreeBas = 0;
            VoiturePlan1.nbVoitureCreeHaut = 0;
            VoiturePlan1.nbVoitureCreeDroite = 0;
            VoiturePlan1.nbVoitureCreeGauche = 0;
            PersonPlan1.nbPersonCreeBas = 0;
            PersonPlan1.nbPersonCreeHaut = 0;
            PersonPlan1.nbPersonCreeDroite = 0;
            PersonPlan1.nbPersonCreeGauche = 0;
        }
        static Plan1()
        {
          
            stopVoitureBas = 500;
            stopVoitureGauche = 460;
            stopVoitureHaut = 170;
            stopVoitureDroite = 830;
            stopPersonBas = 500;
            stopPersonGauche = 510;
            stopPersonHaut = 220;
            stopPersonDroite = 830;
        }
        

    }
    public class Plan1Auto : Plan1
    {
        
        public static int moyenVoitureGauche, moyenVoitureDroite, moyenVoitureHaut, moyenVoitureBas;
        public static int moyenPersonGauche, moyenPersonDroite, moyenPersonHaut, moyenPersonBas;
        public static double tempsDuSimulation;
        public static int rougePourcentage, vertPourcentage;
        public Queue qTempsVoitureHaut, qTempsVoitureDroite, qTempsVoitureGauche, qTempsVoitureBas;
        public VoiturePlan1Auto[] tVoitureHaut, tVoitureDroite, tVoitureGauche, tVoitureBas;
        public Queue qTempsPersonHaut, qTempsPersonDroite, qTempsPersonGauche, qTempsPersonBas;
        public PersonPlan1Auto[] tPersonHaut, tPersonDroite, tPersonGauche, tPersonBas;
       public static int nbVoitureExisteHaut, nbVoitureExisteDroite, nbVoitureExisteGauche, nbVoitureExisteBas;
        public static int nbPersonExisteHaut, nbPersonExisteDroite, nbPersonExisteGauche, nbPersonExisteBas;

       public static void annulerVPExist()
        {
            nbVoitureExisteHaut = nbVoitureExisteDroite = nbVoitureExisteGauche = nbVoitureExisteBas = 0;
            nbPersonExisteHaut = nbPersonExisteDroite = nbPersonExisteGauche = nbPersonExisteBas = 0;


        }
        public static Queue Expo(double mean, double period)
        {

            Queue q = new Queue();
            Random g = new Random();
            double current_time = 0.0, u, inter;
            while (current_time < period)
            {
                u = g.NextDouble(); // u in [0,1]
                inter = -1.0 / mean * Math.Log(1 - u);
                current_time += inter;
                if (current_time < period) q.Enqueue(current_time);
            }
            return q;
        }
        public Plan1Auto()
        {
            fp1 = new feuxPlan1(true);
            qTempsVoitureHaut = Expo(moyenVoitureHaut, tempsDuSimulation);
            qTempsVoitureBas = Expo(moyenVoitureBas, tempsDuSimulation);
            qTempsVoitureDroite = Expo(moyenVoitureDroite, tempsDuSimulation);
            qTempsVoitureGauche = Expo(moyenVoitureGauche, tempsDuSimulation);
            qTempsPersonHaut = Expo(moyenPersonHaut, tempsDuSimulation);
            qTempsPersonBas = Expo(moyenPersonBas, tempsDuSimulation);
            qTempsPersonDroite = Expo(moyenPersonDroite, tempsDuSimulation);
            qTempsPersonGauche = Expo(moyenPersonGauche, tempsDuSimulation);
            tVoitureHaut = new VoiturePlan1Auto[qTempsVoitureHaut.Count];
            tVoitureBas = new VoiturePlan1Auto[qTempsVoitureBas.Count];
            tVoitureDroite = new VoiturePlan1Auto[qTempsVoitureDroite.Count];
            tVoitureGauche = new VoiturePlan1Auto[qTempsVoitureGauche.Count];
            tPersonHaut = new PersonPlan1Auto[qTempsPersonHaut.Count];
            tPersonBas = new PersonPlan1Auto[qTempsPersonBas.Count];
            tPersonDroite = new PersonPlan1Auto[qTempsPersonDroite.Count];
            tPersonGauche = new PersonPlan1Auto[qTempsPersonGauche.Count];
            //for (int i = 0; i < qTempsVoitureDroite.Count; i++)
            //{
            //    tVoitureDroite[i] = new VoiturePlan1Auto("droite");
            //}
            //for (int i = 0; i < qTempsVoitureGauche.Count; i++)
            //{
            //    tVoitureGauche[i] = new VoiturePlan1Auto("gauche");
            //}
            //for (int i = 0; i < qTempsVoitureBas.Count; i++)
            //{
            //    tVoitureBas[i] = new VoiturePlan1Auto("bas");
            //}
            //for (int i = 0; i < qTempsVoitureHaut.Count; i++)
            //{
            //    tVoitureHaut[i] = new VoiturePlan1Auto("haut");
            //}


            //for (int i = 0; i < qTempsPersonDroite.Count; i++)
            //{
            //    tPersonDroite[i] = new PersonPlan1Auto("droite");
            //}
            //for (int i = 0; i < qTempsPersonGauche.Count; i++)
            //{
            //    tPersonGauche[i] = new PersonPlan1Auto("gauche");
            //}
            //for (int i = 0; i < qTempsPersonBas.Count; i++)
            //{
            //    tPersonBas[i] = new PersonPlan1Auto("bas");
            //}
            //for (int i = 0; i < qTempsPersonHaut.Count; i++)
            //{
            //    tPersonHaut[i] = new PersonPlan1Auto("haut");
            //}

        }

    }
    public class Plan1Manuel : Plan1
    {
        public static int nbVoitureCree, nbPersonCree;
        static int nVmax,nPmax;
        public static VoiturePlan1Manuel[] tV;
        public static PersonPlan1Manuel[] tP;
        static Plan1Manuel()
        {
            nVmax = 40;nPmax = 40;
            nbVoitureCree = 0;nbPersonCree = 0;
            tV = new VoiturePlan1Manuel[nVmax];
            tP = new PersonPlan1Manuel[nPmax];
        }

     
        public static void plusVoiture(VoiturePlan1Manuel c)
        {

            if (nbVoitureCree < nVmax) tV[nbVoitureCree] = c;
            else
            {
                nVmax += 40;
                VoiturePlan1Manuel[] aux = new VoiturePlan1Manuel[nVmax];
                for (int i = 0; i < nbVoitureCree; i++) aux[i] = tV[i];
                tV = aux;
                tV[nbVoitureCree] = c;

            }
            nbVoitureCree++;
        }
        public static void plusPerson(PersonPlan1Manuel p)
        {

            if (nbPersonCree < nPmax) tP[nbPersonCree] = p;
            else
            {
                nPmax += 40;
                PersonPlan1Manuel[] aux = new PersonPlan1Manuel[nPmax];
                for (int i = 0; i < nbPersonCree; i++) aux[i] = tP[i];
                tP = aux;
                tP[nbPersonCree] = p;

            }
            nbPersonCree++;
        }
        public Plan1Manuel()
        {
            fp1 = new feuxPlan1(false);
        }
    }
    public class Plan2
    {
        public static bool capableDeQuite, capableVoitureN, capableVoitureZ;
        public static int stopVoitureBas;
        public static int stopVoitureGauche;
        public static int stopVoitureDroite;
        public static int stopPersonBas;
        public static int stopPersonGauche;
        public static int stopPersonHaut;


        public feuxPlan2 fp2;
        public static void annulerVPCree()
        {
            capableDeQuite = false; capableVoitureN = false; capableVoitureZ = false;
            VoiturePlan2.nbVoitureCreeBas = 0;
            VoiturePlan2.nbVoitureCreeDroite = 0;
            VoiturePlan2.nbVoitureCreeGauche = 0;
            PersonPlan2.nbPersonCreeBas = 0;
            PersonPlan2.nbPersonCreeHaut = 0;
            PersonPlan2.nbPersonCreeDroite = 0;
            PersonPlan2.nbPersonCreeGauche = 0;
        }
        static Plan2()
        {

            stopVoitureBas = 500;
            stopVoitureGauche = 460;
            stopVoitureDroite = 830;
            stopPersonBas = 500;
            stopPersonGauche = 510;
            stopPersonHaut = 220;
        }


    }
    public class Plan2Auto : Plan2
    {

        public static int moyenVoitureGauche, moyenVoitureDroite, moyenVoitureBas;
        public static int moyenPersonGauche, moyenPersonDroite, moyenPersonHaut, moyenPersonBas;
        public static double tempsDuSimulation;
        public static int rougePourcentage, vertPourcentage;
        public Queue  qTempsVoitureDroite, qTempsVoitureGauche, qTempsVoitureBas;
        public VoiturePlan2Auto[]  tVoitureDroite, tVoitureGauche, tVoitureBas;
        public Queue qTempsPersonHaut, qTempsPersonDroite, qTempsPersonGauche, qTempsPersonBas;
        public PersonPlan2Auto[] tPersonHaut, tPersonDroite, tPersonGauche, tPersonBas;
        public static int  nbVoitureExisteDroite, nbVoitureExisteGauche, nbVoitureExisteBas;
        public static int nbPersonExisteHaut, nbPersonExisteDroite, nbPersonExisteGauche, nbPersonExisteBas;

        public static void annulerVPExist()
        {
            nbVoitureExisteDroite = nbVoitureExisteGauche = nbVoitureExisteBas = 0;
            nbPersonExisteHaut = nbPersonExisteDroite = nbPersonExisteGauche = nbPersonExisteBas = 0;


        }
        public static Queue Expo(double mean, double period)
        {

            Queue q = new Queue();
            Random g = new Random();
            double current_time = 0.0, u, inter;
            while (current_time < period)
            {
                u = g.NextDouble(); // u in [0,1]
                inter = -1.0 / mean * Math.Log(1 - u);
                current_time += inter;
                if (current_time < period) q.Enqueue(current_time);
            }
            return q;
        }
        public Plan2Auto()
        {
            fp2 = new feuxPlan2(true);
            qTempsVoitureBas = Expo(moyenVoitureBas, tempsDuSimulation);
            qTempsVoitureDroite = Expo(moyenVoitureDroite, tempsDuSimulation);
            qTempsVoitureGauche = Expo(moyenVoitureGauche, tempsDuSimulation);
            qTempsPersonHaut = Expo(moyenPersonHaut, tempsDuSimulation);
            qTempsPersonBas = Expo(moyenPersonBas, tempsDuSimulation);
            qTempsPersonDroite = Expo(moyenPersonDroite, tempsDuSimulation);
            qTempsPersonGauche = Expo(moyenPersonGauche, tempsDuSimulation);
            tVoitureBas = new VoiturePlan2Auto[qTempsVoitureBas.Count];
            tVoitureDroite = new VoiturePlan2Auto[qTempsVoitureDroite.Count];
            tVoitureGauche = new VoiturePlan2Auto[qTempsVoitureGauche.Count];
            tPersonHaut = new PersonPlan2Auto[qTempsPersonHaut.Count];
            tPersonBas = new PersonPlan2Auto[qTempsPersonBas.Count];
            tPersonDroite = new PersonPlan2Auto[qTempsPersonDroite.Count];
            tPersonGauche = new PersonPlan2Auto[qTempsPersonGauche.Count];
            //for (int i = 0; i < qTempsVoitureDroite.Count; i++)
            //{
            //    tVoitureDroite[i] = new VoiturePlan2Auto("droite");
            //}
            //for (int i = 0; i < qTempsVoitureGauche.Count; i++)
            //{
            //    tVoitureGauche[i] = new VoiturePlan2Auto("gauche");
            //}
            //for (int i = 0; i < qTempsVoitureBas.Count; i++)
            //{
            //    tVoitureBas[i] = new VoiturePlan2Auto("bas");
            //}


            //for (int i = 0; i < qTempsPersonDroite.Count; i++)
            //{
            //    tPersonDroite[i] = new PersonPlan2Auto("droite");
            //}
            //for (int i = 0; i < qTempsPersonGauche.Count; i++)
            //{
            //    tPersonGauche[i] = new PersonPlan2Auto("gauche");
            //}
            //for (int i = 0; i < qTempsPersonBas.Count; i++)
            //{
            //    tPersonBas[i] = new PersonPlan2Auto("bas");
            //}
            //for (int i = 0; i < qTempsPersonHaut.Count; i++)
            //{
            //    tPersonHaut[i] = new PersonPlan2Auto("haut");
            //}

        }

    }
    public class Plan2Manuel : Plan2
    {
        public static int nbVoitureCree, nbPersonCree;
        static int nVmax, nPmax;
        public static VoiturePlan2Manuel[] tV;
        public static PersonPlan2Manuel[] tP;
        static Plan2Manuel()
        {
            nVmax = 40; nPmax = 40;
            nbVoitureCree = 0; nbPersonCree = 0;
            tV = new VoiturePlan2Manuel[nVmax];
            tP = new PersonPlan2Manuel[nPmax];
        }


        public static void plusVoiture(VoiturePlan2Manuel c)
        {

            if (nbVoitureCree < nVmax) tV[nbVoitureCree] = c;
            else
            {
                nVmax += 40;
                VoiturePlan2Manuel[] aux = new VoiturePlan2Manuel[nVmax];
                for (int i = 0; i < nbVoitureCree; i++) aux[i] = tV[i];
                tV = aux;
                tV[nbVoitureCree] = c;

            }
            nbVoitureCree++;
        }
        public static void plusPerson(PersonPlan2Manuel p)
        {

            if (nbPersonCree < nPmax) tP[nbPersonCree] = p;
            else
            {
                nPmax += 40;
                PersonPlan2Manuel[] aux = new PersonPlan2Manuel[nPmax];
                for (int i = 0; i < nbPersonCree; i++) aux[i] = tP[i];
                tP = aux;
                tP[nbPersonCree] = p;

            }
            nbPersonCree++;
        }
        public Plan2Manuel()
        {
            fp2= new feuxPlan2(false);
        }
    }
    public class Plan3
    {
       
        public static int stopVoitureBas;
        public static int stopVoitureGauche;
        public static int stopAmbulanceBas;
        public static int stopAmbulanceGauche;
        public static int stopPersonGauche;
        public static int stopPersonHaut;
        public static bool capableDeQuiteZ, capableDeQuiteN, capableVoitureN, capableVoitureZ;
        public feuxPlan3 fp3;
        public static void annulerVPCree()
        {
            capableDeQuiteZ = false; capableDeQuiteN = false; capableVoitureN = false; capableVoitureZ = false;
            VoiturePlan3.nbVoitureCreeBas = 0;
            VoiturePlan3.nbVoitureCreeGauche = 0;
            PersonPlan3.nbPersonCreeHaut = 0;
            PersonPlan3.nbPersonCreeGauche = 0;
        }
        static Plan3()
        {
            stopAmbulanceBas=500;
            stopAmbulanceGauche = 560;   stopVoitureBas = 500;
            stopVoitureGauche = 560;
            stopPersonGauche = 624;
            stopPersonHaut = 303;
        }
    }
    public class Plan3Auto : Plan3
    {

        public static int moyenVoitureGauche, moyenVoitureBas;
        public static int moyenPersonGauche, moyenPersonHaut;
        public static double tempsDuSimulation;
        public static int rougePourcentage, vertPourcentage;
        public Queue  qTempsVoitureGauche, qTempsVoitureBas;
        public VoiturePlan3Auto[]  tVoitureGauche, tVoitureBas;
        public Queue qTempsPersonHaut, qTempsPersonGauche;
        public PersonPlan3Auto[] tPersonHaut,  tPersonGauche;
        public static int nbVoitureExisteGauche, nbVoitureExisteBas;
        public static int nbPersonExisteHaut,  nbPersonExisteGauche;
        public static int nbAmbulanceExisteGauche, nbAmbulanceExisteBas;
        public static void annulerVPExist()
        {
            nbVoitureExisteGauche = nbVoitureExisteBas = nbAmbulanceExisteBas= nbAmbulanceExisteGauche=0;
            nbPersonExisteHaut  = nbPersonExisteGauche =  0;


        }
        public static Queue Expo(double mean, double period)
        {

            Queue q = new Queue();
            Random g = new Random();
            double current_time = 0.0, u, inter;
            while (current_time < period)
            {
                u = g.NextDouble(); // u in [0,1]
                inter = -1.0 / mean * Math.Log(1 - u);
                current_time += inter;
                if (current_time < period) q.Enqueue(current_time);
            }
            return q;
        }
        public Plan3Auto()
        {
            fp3 = new feuxPlan3(true);
            qTempsVoitureBas = Expo(moyenVoitureBas, tempsDuSimulation);
            qTempsVoitureGauche = Expo(moyenVoitureGauche, tempsDuSimulation);
            qTempsPersonHaut = Expo(moyenPersonHaut, tempsDuSimulation);
            qTempsPersonGauche = Expo(moyenPersonGauche, tempsDuSimulation);
            tVoitureBas = new VoiturePlan3Auto[qTempsVoitureBas.Count];
            tVoitureGauche = new VoiturePlan3Auto[qTempsVoitureGauche.Count];
            tPersonHaut = new PersonPlan3Auto[qTempsPersonHaut.Count];
            tPersonGauche = new PersonPlan3Auto[qTempsPersonGauche.Count];
            //for (int i = 0; i < qTempsVoitureGauche.Count; i++)
            //{
            //    tVoitureGauche[i] = new VoiturePlan3Auto("gauche");
            //}
            //for (int i = 0; i < qTempsVoitureBas.Count; i++)
            //{
            //    tVoitureBas[i] = new VoiturePlan3Auto("bas");
            //}



            //for (int i = 0; i < qTempsPersonGauche.Count; i++)
            //{
            //    tPersonGauche[i] = new PersonPlan3Auto("gauche");
            //}
            //for (int i = 0; i < qTempsPersonHaut.Count; i++)
            //{
            //    tPersonHaut[i] = new PersonPlan3Auto("haut");
            //}

        }

    }
    public class Plan3Manuel : Plan3
    {
        public static int nbVoitureCree, nbPersonCree;
        static int nVmax, nPmax;
        public static VoiturePlan3Manuel[] tV;
        public static PersonPlan3Manuel[] tP;
        static Plan3Manuel()
        {
            nVmax = 40; nPmax = 40;
            nbVoitureCree = 0; nbPersonCree = 0;
            tV = new VoiturePlan3Manuel[nVmax];
            tP = new PersonPlan3Manuel[nPmax];
        }


        public static void plusVoiture(VoiturePlan3Manuel c)
        {

            if (nbVoitureCree < nVmax) tV[nbVoitureCree] = c;
            else
            {
                nVmax += 40;
                VoiturePlan3Manuel[] aux = new VoiturePlan3Manuel[nVmax];
                for (int i = 0; i < nbVoitureCree; i++) aux[i] = tV[i];
                tV = aux;
                tV[nbVoitureCree] = c;

            }
            nbVoitureCree++;
        }
        public static void plusPerson(PersonPlan3Manuel p)
        {

            if (nbPersonCree < nPmax) tP[nbPersonCree] = p;
            else
            {
                nPmax += 40;
                PersonPlan3Manuel[] aux = new PersonPlan3Manuel[nPmax];
                for (int i = 0; i < nbPersonCree; i++) aux[i] = tP[i];
                tP = aux;
                tP[nbPersonCree] = p;

            }
            nbPersonCree++;
        }
        public Plan3Manuel()
        {
            fp3 = new feuxPlan3(false);
        }
    }
    public class Plan4
    {
        public static int stopambulance;
        public static int stopVoitureBasDroite;
        public static int stopVoitureGaucheBas;
        public static int stopVoitureBasGauche;
        public static int stopVoitureGaucheHaut;
        public static int stopPersonGauche;
        public static bool capableDeQuiteZ, capableDeQuiteN, capableVoitureN, capableVoitureZ;


        public feuxPlan4 fp4;
        public static void annulerVPCree()
        {
            capableDeQuiteZ = false; capableDeQuiteN = false; capableVoitureN = false; capableVoitureZ = false;

            VoiturePlan4.nbVoitureCreeBasDroite = 0;
            VoiturePlan4.nbVoitureCreeGaucheBas = 0;
            VoiturePlan4.nbVoitureCreeBasGauche = 0;
            VoiturePlan4.nbVoitureCreeGaucheHaut = 0;
            PersonPlan4.nbPersonCreeDroite = 0;
            PersonPlan4.nbPersonCreeGauche = 0;
        }
        static Plan4()
        {

            stopVoitureBasGauche = 500; stopVoitureBasDroite = 500;
            stopVoitureGaucheBas = 460; stopVoitureGaucheHaut = 460;
            stopPersonGauche = 510; stopambulance = 460;
        }


    }
    public class Plan4Auto : Plan4
    {

        public static int moyenVoitureGaucheBas, moyenVoitureGaucheHaut, moyenVoitureBasDroite, moyenVoitureBasGauche;
        public static int moyenPersonGauche, moyenPersonDroite, moyenPersonHaut;
        public static double tempsDuSimulation;
        public static int rougePourcentage, vertPourcentage;
        public Queue  qTempsVoitureGaucheBas, qTempsVoitureGaucheHaut, qTempsVoitureBasGauche, qTempsVoitureBasDroite;
        public VoiturePlan4Auto[]  tVoitureGaucheBas, tVoitureGaucheHaut, tVoitureBasGauche, tVoitureBasDroite;
        public Queue qTempsPersonHaut, qTempsPersonDroite, qTempsPersonGauche;
        public PersonPlan4Auto[] tPersonHaut, tPersonDroite, tPersonGauche;
        public static int  nbVoitureExisteGaucheBas, nbVoitureExisteGaucheHaut, nbVoitureExisteBasGauche,nbVoitureExisteBasDroite;
        public static int nbPersonExisteHaut, nbPersonExisteDroite, nbPersonExisteGauche;

        public static void annulerVPExist()
        {
            nbVoitureExisteGaucheBas = nbVoitureExisteGaucheHaut = nbVoitureExisteBasGauche = nbVoitureExisteBasDroite = 0;
            nbPersonExisteHaut = nbPersonExisteDroite = nbPersonExisteGauche=0;


        }
        public static Queue Expo(double mean, double period)
        {

            Queue q = new Queue();
            Random g = new Random();
            double current_time = 0.0, u, inter;
            while (current_time < period)
            {
                u = g.NextDouble(); // u in [0,1]
                inter = -1.0 / mean * Math.Log(1 - u);
                current_time += inter;
                if (current_time < period) q.Enqueue(current_time);
            }
            return q;
        }
        public Plan4Auto()
        {
            fp4 = new feuxPlan4(true);
            qTempsVoitureBasGauche = Expo(moyenVoitureBasGauche, tempsDuSimulation);           
            qTempsVoitureGaucheBas = Expo(moyenVoitureGaucheBas, tempsDuSimulation);
            qTempsVoitureBasDroite = Expo(moyenVoitureBasDroite, tempsDuSimulation);
            qTempsVoitureGaucheHaut = Expo(moyenVoitureGaucheHaut, tempsDuSimulation);
            qTempsPersonDroite = Expo(moyenPersonDroite, tempsDuSimulation);
            qTempsPersonGauche = Expo(moyenPersonGauche, tempsDuSimulation);
            tVoitureBasGauche = new VoiturePlan4Auto[qTempsVoitureBasGauche.Count];           
            tVoitureGaucheBas = new VoiturePlan4Auto[qTempsVoitureGaucheBas.Count];
            tVoitureBasDroite = new VoiturePlan4Auto[qTempsVoitureBasDroite.Count];
            tVoitureGaucheHaut = new VoiturePlan4Auto[qTempsVoitureGaucheHaut.Count];          
            tPersonDroite = new PersonPlan4Auto[qTempsPersonDroite.Count];
            tPersonGauche = new PersonPlan4Auto[qTempsPersonGauche.Count];
            //for (int i = 0; i < qTempsVoitureGaucheBas.Count; i++)
            //{
            //    tVoitureGaucheBas[i] = new VoiturePlan4Auto("gaucheBas");
            //}
            //for (int i = 0; i < qTempsVoitureGaucheHaut.Count; i++)
            //{
            //    tVoitureGaucheHaut[i] = new VoiturePlan4Auto("gaucheHaut");
            //}
            //for (int i = 0; i < qTempsVoitureBasGauche.Count; i++)
            //{
            //    tVoitureBasGauche[i] = new VoiturePlan4Auto("basGauche");
            //}
            //for (int i = 0; i < qTempsVoitureBasDroite.Count; i++)
            //{
            //    tVoitureBasDroite[i] = new VoiturePlan4Auto("basDroite");
            //}


            //for (int i = 0; i < qTempsPersonDroite.Count; i++)
            //{
            //    tPersonDroite[i] = new PersonPlan4Auto("droite");
            //}
            //for (int i = 0; i < qTempsPersonGauche.Count; i++)
            //{
            //    tPersonGauche[i] = new PersonPlan4Auto("gauche");
            //}
           

        }

    }
    public class Plan4Manuel : Plan4
    {
        public static int nbVoitureCree, nbPersonCree;
        static int nVmax, nPmax;
        public static VoiturePlan4Manuel[] tV;
        public static PersonPlan4Manuel[] tP;
        static Plan4Manuel()
        {
            nVmax = 40; nPmax = 40;
            nbVoitureCree = 0; nbPersonCree = 0;
            tV = new VoiturePlan4Manuel[nVmax];
            tP = new PersonPlan4Manuel[nPmax];
        }


        public static void plusVoiture(VoiturePlan4Manuel c)
        {

            if (nbVoitureCree < nVmax) tV[nbVoitureCree] = c;
            else
            {
                nVmax += 40;
                VoiturePlan4Manuel[] aux = new VoiturePlan4Manuel[nVmax];
                for (int i = 0; i < nbVoitureCree; i++) aux[i] = tV[i];
                tV = aux;
                tV[nbVoitureCree] = c;

            }
            nbVoitureCree++;
        }
        public static void plusPerson(PersonPlan4Manuel p)
        {

            if (nbPersonCree < nPmax) tP[nbPersonCree] = p;
            else
            {
                nPmax += 40;
                PersonPlan4Manuel[] aux = new PersonPlan4Manuel[nPmax];
                for (int i = 0; i < nbPersonCree; i++) aux[i] = tP[i];
                tP = aux;
                tP[nbPersonCree] = p;

            }
            nbPersonCree++;
        }
        public Plan4Manuel()
        {
            fp4 = new feuxPlan4(false);
        }
    }
    public class Plan5
    {
        public static int stopVoitureBasBas;
        public static int stopVoitureDroiteBas;
        public static int stopVoitureHautDroite;
        public static int stopVoitureBasGauche;
        public static int stopVoitureGaucheGauche;
        public static int stopVoitureGaucheHaut;
        public static int stopVoitureHautHaut;
        public static int stopVoitureDroiteDroite;
        public static bool capableZawya;
        public static bool capableNos;


        public feuxPlan5 fp5;
        public static void annulerVPCree()
        {

            VoiturePlan5.nbVoitureCreeBas = 0;
            VoiturePlan5.nbVoitureCreeHaut = 0;
            VoiturePlan5.nbVoitureCreeDroite = 0;
            VoiturePlan5.nbVoitureCreeGauche = 0;
        }
        static Plan5()
        {
            stopVoitureBasBas=610;
            stopVoitureDroiteBas=240;
            stopVoitureHautDroite=400;
            stopVoitureBasGauche=900;
            stopVoitureGaucheGauche=220;
            stopVoitureGaucheHaut=425;
            stopVoitureHautHaut=60;
            stopVoitureDroiteDroite=1075;

        }

    }
    public class Plan5Auto : Plan5
    {

        public static int moyenVoitureGauche, moyenVoitureDroite, moyenVoitureHaut, moyenVoitureBas;
        public static double tempsDuSimulation;
        public Queue qTempsVoitureHaut, qTempsVoitureDroite, qTempsVoitureGauche, qTempsVoitureBas;
        public VoiturePlan5Auto[] tVoitureHaut, tVoitureDroite, tVoitureGauche, tVoitureBas;
        public static int nbVoitureExisteHaut, nbVoitureExisteDroite, nbVoitureExisteGauche, nbVoitureExisteBas;


        public static void annulerVPExist()
        {
            nbVoitureExisteHaut = nbVoitureExisteDroite = nbVoitureExisteGauche = nbVoitureExisteBas = 0;


        }
        public static Queue Expo(double mean, double period)
        {

            Queue q = new Queue();
            Random g = new Random();
            double current_time = 0.0, u, inter;
            while (current_time < period)
            {
                u = g.NextDouble(); // u in [0,1]
                inter = -1.0 / mean * Math.Log(1 - u);
                current_time += inter;
                if (current_time < period) q.Enqueue(current_time);
            }
            return q;
        }
        public Plan5Auto()
        {
            fp5 = new feuxPlan5();
            qTempsVoitureHaut = Expo(moyenVoitureHaut, tempsDuSimulation);
            qTempsVoitureBas = Expo(moyenVoitureBas, tempsDuSimulation);
            qTempsVoitureDroite = Expo(moyenVoitureDroite, tempsDuSimulation);
            qTempsVoitureGauche = Expo(moyenVoitureGauche, tempsDuSimulation);
            tVoitureHaut = new VoiturePlan5Auto[qTempsVoitureHaut.Count];
            tVoitureBas = new VoiturePlan5Auto[qTempsVoitureBas.Count];
            tVoitureDroite = new VoiturePlan5Auto[qTempsVoitureDroite.Count];
            tVoitureGauche = new VoiturePlan5Auto[qTempsVoitureGauche.Count];
            //for (int i = 0; i < qTempsVoitureDroite.Count; i++)
            //{
            //    tVoitureDroite[i] = new VoiturePlan5Auto("droite");
            //}
            //for (int i = 0; i < qTempsVoitureGauche.Count; i++)
            //{
            //    tVoitureGauche[i] = new VoiturePlan5Auto("gauche");
            //}
            //for (int i = 0; i < qTempsVoitureBas.Count; i++)
            //{
            //    tVoitureBas[i] = new VoiturePlan5Auto("bas");
            //}
            //for (int i = 0; i < qTempsVoitureHaut.Count; i++)
            //{
            //    tVoitureHaut[i] = new VoiturePlan5Auto("haut");
            //}

        }

    }
}
