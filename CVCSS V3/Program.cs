using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVCSS_V3
{
    class Program
    { 
        public static string Qualitative(double y)
        {
            string x = "";
            if (y == 0)
            {
                x = "Опасность отсутствует";
            }
            else if (y >= 0.1 & y <= 3.9)
            {
                x = "Низкий";
            }
            else if (y >= 4 && y <= 6.9)
            {
                x = "Средний";
            }
            else if (y >= 7 && y <= 8.9)
            {
                x = "Высокий";
            }
            else if (y >=9 && y<=10)
            {
                x = "Критический";
            }
            return "Уровень опасности: " + x;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Оцените влияние на другие компоненты системы, введя нужное обозначение");
            double S = -1;
            Console.WriteLine("U - не оказывается, C - оказывается");
            switch (Console.ReadLine())
            {
                case "U":
                    S = 0;
                    break;
                case "C":
                    S = 1;
                    break;
            }
            Console.WriteLine("Оцените вектор аттак, введя нужное обозначение");
            double AV = -1;
            Console.WriteLine("P - физический, L - локальный, A - смежная сеть, N - сетевой");
            switch (Console.ReadLine())
            {
                case "P":
                    AV = 0.2;
                    break;
                case "L":
                    AV = 0.55;
                    break;
                case "A":
                    AV = 0.62;
                    break;
                case "N":
                     AV = 0.85;
                    break;
            }
            Console.WriteLine("Оцените сложность экспуатации уязвимости, введя нужное обозначение");
            double AC = -1;
            Console.WriteLine("H - высокая, L - низкая");
            switch(Console.ReadLine())
            {
                case "H": AC = 0.44;
                    break;
                case "L": AC = 0.77;
                    break;
            }
            Console.WriteLine("Оцените уровень привелегий, введя нужное обозначение");
            double PR=-1;
            Console.WriteLine("H - высокая, L - низкая, N - нулевая");
            switch (Console.ReadLine())
            {
                case "N":
                    PR = 0.85;
                    break;
                case "L":
                    if (S == 1)
                    {
                        PR = 0.68;
                        break;
                    }
                    PR = 0.62; //s!=1
                    break;
                case "H":
                    if (S == 1)
                    {
                        PR = 0.50;
                        break;
                    }
                    PR = 0.27; //s!=1
                    break;
            }
            Console.WriteLine("Оцените взаимодествие с пользователями, введя нужное обозначение");
            double UI = -1;
            Console.WriteLine("N - не требуется, R - требуется");
            switch (Console.ReadLine())
            {
                case "N":
                    UI = 0.85;
                    break;
                case "R":
                    UI = 0.62;
                    break;
            }
            double X()
            {
                double x = -1;
                Console.WriteLine("H - высокая, L - низкая, N - нулевая");
                switch (Console.ReadLine())
                {
                    case "N":
                        x = 0;
                        break;
                    case "L":
                        x = 0.22;
                        break;
                    case "H":
                        x = 0.66;
                        break;
                }
                return x;
            }
            Console.WriteLine("Оцените влияние на конфиденциальность, введя нужное обозначение");
            double C = X();
            Console.WriteLine("Оцените влияние на целостность, введя нужное обозначение");
            double I = X();
            Console.WriteLine("Оцените влияние на доступность, введя нужное обозначение");
            double A = X();
            double BaseScore, Impact;
            double ImpactBase = 1 - ((1 - C) * (1 - I) * (1 - A));
            double Exp = 8.22 * AC *AV *PR*UI;
            if (S==0)
            {
                Impact = 6.42 * ImpactBase;
                BaseScore = Math.Ceiling(Math.Min(Math.Ceiling((Impact + Exp)*10)/10, 10)*10)/10;
               double  BaseScoretry = Math.Ceiling(Math.Ceiling(Math.Min(Impact+Exp, 10)*10))/10;
            }
            else
            {
                Impact = 7.52 * (ImpactBase - 0.029) - 3.25 * Math.Pow(ImpactBase - 0.02, 15);
                BaseScore = Math.Min(Math.Ceiling(1.08*(Impact+Exp)*10)/10,10);
            }
            if (Impact<=0)
            {
                BaseScore = 0;
            }

            Console.WriteLine("Базовая оценка: " + BaseScore);
            Console.WriteLine(Qualitative(BaseScore));
            //temporal score//
            Console.WriteLine("Оцените доступность средств эксплуатации");
            double E = -1;
            Console.WriteLine("X - не определено, U - теоретически, P - есть концепция, F - есть сценарий, H - высокая");
            switch (Console.ReadLine())
            {
                case "X":
                    E = 1;
                    break;
                case "U":
                    E = 0.91;
                    break;
                case "P":
                    E = 0.94;
                    break;
                case "F":
                    E = 0.97;
                    break;
                case "H":
                    E = 1;
                    break;
            }
            Console.WriteLine(E);
            Console.WriteLine("Оцените уровень исправления");
            double RL = -1;
            Console.WriteLine("X - не определено, O - официальное, T - временное, W - рекомендации, U - недоступно");
            switch (Console.ReadLine())
            {
                case "X":
                    RL = 1;
                    break;
                case "O":
                    RL = 0.95;
                    break;
                case "T":
                    RL = 0.96;
                    break;
                case "W":
                    RL = 0.97;
                    break;
                case "U":
                    RL = 1;
                    break;
            }
            Console.WriteLine(RL);
            Console.WriteLine("Оцените степень достоверности источника");
            double RC = -1;
            Console.WriteLine("X - не определено, U - отчеты, R - достоверные отчеты, C - подтверждена");
            switch (Console.ReadLine())
            {
                case "X":
                    RC = 1;
                    break;
                case "U":
                    RC = 0.92;
                    break;
                case "R":
                    RC = 0.96;
                    break;
                case "C":
                    RC = 1;
                    break;
            }
            Console.WriteLine(RC);
            double TemporalScore = Math.Ceiling(BaseScore * E * RL * RC * 10) / 10;
            Console.WriteLine("Временная оценка: " + TemporalScore);
            Console.WriteLine(Qualitative(TemporalScore));
            //temporal score//
            //modfied score//
            double ModyfiedX(double y)
            {
                Console.WriteLine("X - не определено, N - нулевая, L - низкая, H - высокая");
                double x = -1;
                switch (Console.ReadLine())
                {
                    case "X":
                        x = y;
                        break;
                    case "N":
                        x = 0;
                        break;
                    case "L":
                        x = 0.22;
                        break;
                    case "H":
                        x = 0.56;
                        break;
                }
                return x;
            }
            double XR()
            {
                Console.WriteLine("X - не определено, H - высокая, M - средняя, L - низкая");
                double x = -1;
                switch (Console.ReadLine())
                {
                    case "X":
                        x = 1;
                        break;
                    case "H":
                        x = 1.5;
                        break;
                    case "M":
                        x = 1;
                        break;
                    case "L":
                        x = 0.5;
                        break;
                }
                return x;
            }
            Console.WriteLine("Оцените скорректированное влияние на другие компоненты системы");
            double MS=-1;
            Console.WriteLine("X -не поределено, U - не оказывается, C - оказывается");
            switch (Console.ReadLine())
            {
                case "X":
                    MS = S;
                    break;
                case "U":
                    MS = 0;
                    break;
                case "C":
                    MS = 1;
                    break;
            }
            Console.WriteLine("Оцените скорректированный вектор аттаки");
            double MAV = -1;
            Console.WriteLine("X - не определено, P - физический, L - локальный, A - смежная сеть, N - сетевой");
            switch (Console.ReadLine())
            {
                case "X":
                    MAV = AV;
                    break;
                case "P":
                    MAV = 0.2;
                    break;
                case "L":
                    MAV = 0.55;
                    break;
                case "A":
                    MAV = 0.62;
                    break;
                case "N":
                    MAV = 0.85;
                    break;
            }
            Console.WriteLine("Оцените скорректированную сложность аттаки");
            double MAC = -1;
            Console.WriteLine("H - высокая, L - низкая, X - не определено");
            switch (Console.ReadLine())
            {
                case "X":
                    MAC = AC;
                    break;
                case "H":
                    MAC = 0.44;
                    break;
                case "L":
                    MAC = 0.77;
                    break;
            }
            Console.WriteLine("Оцените скорректированный уровень привелегий");
            double MPR = -1;
            Console.WriteLine("X - не определено, H - высокая, L - низкая, N - нулевая");
            switch (Console.ReadLine())
            {
                case "X":
                    MPR = PR;
                    break;
                case "N":
                    MPR = 0.85;
                    break;
                case "L":
                    if (MS == 1)
                    {
                        MPR = 0.68;
                        break;
                    }
                    MPR = 0.62; //s!=1
                    break;
                case "H":
                    if (MS == 1)
                    {
                        MPR = 0.50;
                        break;
                    }
                    MPR = 0.27; //s!=1
                    break;
            }
            Console.WriteLine("Оцените скорректированное взаимодействие с пользователями");
            double MUI = -1;
            Console.WriteLine("X - не определено, N - не требуется, R - требуется");
            switch (Console.ReadLine())
            {
                case "X":
                    MUI = UI;
                    break;
                case "N":
                    MUI = 0.85;
                    break;
                case "R":
                    MUI = 0.62;
                    break;
            }

            Console.WriteLine("Оцените скорректрированное влияние на конфиденциальность");
            double MC = ModyfiedX(C);
            Console.WriteLine(MC);
            Console.WriteLine("Оцените скорректрированное влияние на целостность");
            double MI = ModyfiedX(I);
            Console.WriteLine("Оцените скорректрированное влияние на доступность");
            double MA = ModyfiedX(A);

            Console.WriteLine("Оцените требование к конфиденциальности");
            double CR = XR();
            Console.WriteLine("Оцените требование к целостности");
            double IR = XR();
            Console.WriteLine("Оцените требование к доступности");
            double AR = XR();
            double MImpactBase = Math.Min(1 - (1 - MC * CR) * (1 - MI * IR) * (1 - MA * AR), 0.915);
            double MExp = 8.22 * MAV * MAC * MPR * MUI;
            double MImpact, EnvScore;
            if (MS==0)
            {
                MImpact = 6.42 * MImpactBase;
                EnvScore =  Math.Ceiling(Math.Ceiling(Math.Min((MImpact+MExp), 10)*E*RL*RC*10))/10;
            }
            else
            {
                MImpact = 7.52 * (MImpactBase - 0.029) - 3.25 * Math.Pow((MImpactBase - 0.02), 15);
                EnvScore = Math.Ceiling(Math.Ceiling(Math.Min(1.08*(MImpact + MExp), 10) * E * RL * RC * 10)) / 10;
            }
            if (MImpact<=0)
            {
                EnvScore = 0;
            }
            Console.WriteLine("Контекстная оценка: " + EnvScore);
            Console.WriteLine(Qualitative(EnvScore));
            //modfied score//
           
            Console.ReadKey();
            
        }

    }
}
