using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleFM_Project
{

    enum Buff
    {

        STRENGTH_UP = 10,
        STAMINA_UP,
        JUMPING_UP,
        SHOTPOWER_UP,
        REFLECTION_UP,
        AGILLITY_UP,
        SPRINT_UP,
        ACCELERATION_UP,
        PASSINGACCURACY_UP,
        HEADINGACCURACY_UP,
        SHOTACCURACY_UP,
        DRIBBLE_UP,
        TACKLE_UP,
        SLIDINGTACKLE_UP,
        MANTOMAN_UP,
        POSITIONING_UP,
        VISION_UP,
        GK_HANDLING_UP,
        GK_ONEONONE_UP,
        GK_DIVING_UP

    }

    enum Debuff
    {

        STRENGTH_DOWN = 10,
        STAMINA_DOWN,
        JUMPING_DOWN,
        SHOTPOWER_DOWN,
        REFLECTION_DOWN,
        AGILLITY_DOWN,
        SPRINT_DOWN,
        ACCELERATION_DOWN,
        PASSINGACCURACY_DOWN,
        HEADINGACCURACY_DOWN,
        SHOTACCURACY_DOWN,
        DRIBBLE_DOWN,
        TACKLE_DOWN,
        SLIDINGTACKLE_DOWN,
        MANTOMAN_DOWN,
        POSITIONING_DOWN,
        VISION_DOWN,
        GK_HANDLING_DOWN,
        GK_ONEONONE_DOWN,
        GK_DIVING_DOWN

    }

    public class Player : Human
    {

        static List<String> buffList = new List<String>();      //버프 리스트 
        static List<String> debuffList = new List<String>();    //디버프 리스트

        public override void SnackBar()
        {

            base.SnackBar();

        }

        int backNumb;       //등번호 
        string position;    //포지션 
        string prefFoot;    //선호하는 발
        int weakFoot;       //약한 발
        int overall;

        public Player(string name, int backNumb, string position, string prefFoot, int weakFoot, int overall) //Player 클래스 생성자
        {

            this.name = name;           //human 의 name = 매개변수 name 으로 초기화
            this.backNumb = backNumb;   //Player 클래스 backNumb = 생성자 매개변수 backNumb 으로 초기화
            this.position = position;   //이 변수 포함 이아래는 위와 동일
            this.prefFoot = prefFoot;
            this.weakFoot = weakFoot;
            this.overall = overall;

        }

        public static void PlayerInfo()    //플레이어 입력 정보 한번에 출력하는 메소드
        {

            Console.Clear();

            Console.WriteLine("ㅁ Starting Player List ㅁ");
            Console.WriteLine("");

            for (int i = 0; i < Program.playerList.Count; i++)
            {

                Console.WriteLine("Number: {0} | Position: {1} | Name: {2} | Preferred Foot: {3} | Weak Foot: {4} | Overall: {5}"
                             , Program.numbList[i], Program.posiList[i], Program.nameList[i], Program.footList[i], Program.weakList[i], Program.overallList[i]);

            }
            Console.WriteLine("");

            Console.WriteLine("====================\n");


            Console.WriteLine("ㅁ Sub Player List ㅁ");

            for (int i = 0; i < Program.subPlayerList.Count; i++)
            {


                Console.WriteLine("Number: {0} | Position: {1} | Name: {2} | Preferred Foot: {3} | Weak Foot: {4} | Overall: {5}"
                             , Program.subNumbList[i], Program.subPosiList[i], Program.subNameList[i], Program.subFootList[i], Program.subWeakList[i], Program.subOverallList[i]);

            }
            Console.WriteLine("");

        }

        public void BuffAndDebuff()
        {

            StreamReader buff = new StreamReader(@"C:\Users\q\source\repos\ConsoleFM_Project\ConsoleFM_Project\Database\Buff.txt");
            StreamReader debuff = new StreamReader(@"C:\Users\q\source\repos\ConsoleFM_Project\ConsoleFM_Project\Database\DeBuff.txt");

            //스트림리더 를 이용해 폴더안의 메모장 파일을 읽어옴

            string buffContents = "";
            string debuffContents = "";

            while (buff.Peek() >= 0) //리스트에 추가하는 부분
            {

                buffContents = buff.ReadLine();
                debuffContents = debuff.ReadLine();
                buffList.Add(buffContents);
                debuffList.Add(debuffContents);

            }

            Buff buffEnum;
            Debuff debuffEnum;

            Dictionary<Buff, string> buffDictonary = new Dictionary<Buff, string>();
            Dictionary<Debuff, string> debuffDictonary = new Dictionary<Debuff, string>();

            for (int i = 0; i < buffList.Count; i++)
            {

                buffDictonary.Add((Buff)i, buffList[i]);
                debuffDictonary.Add((Debuff)i, debuffList[i]);

            }

            Random randomBuff = new Random();
            Random randomDebuff = new Random();

            int buffNumb = randomBuff.Next(0, 48);
            int debuffNumb = randomDebuff.Next(0, 46);

            buffEnum = (Buff)buffNumb;
            debuffEnum = (Debuff)debuffNumb;

            for (int i = 0; i < buffList.Count + 1; i++)
            {

                if (i == buffNumb) Console.WriteLine(buffList[i]);

                else continue;

            }

            for (int i = 0; i < debuffList.Count + 1; i++)
            {

                if (i == debuffNumb) Console.WriteLine(debuffList[i]);

                else continue;

            }

            Console.WriteLine("Coach Influence: " + Coach.influence);

            if (Coach.influence >= 1 && Coach.influence < 5)
            {

                Program.strength += 1;
                Program.stamina += 1;
                Program.jump += 1;
                Program.shotPower += 1;
                Program.reaction += 1;
                Program.agility += 1;
                Program.sprint += 1;
                Program.accel += 1;
                Program.passAc += 1;
                Program.headAc += 1;
                Program.shotAc += 1;
                Program.dribble += 1;
                Program.tackle += 1;
                Program.sliding += 1;
                Program.mantoman += 1;
                Program.positioning += 1;
                Program.vision += 1;
                Program.gk_handle += 1;
                Program.gk_onetoone += 1;
                Program.gk_diving += 1;

                Console.WriteLine("모든 능력치 가 +1 되었습니다.");

            }

            if (Coach.influence >= 5 && Coach.influence < 10)
            {


                Program.strength += 2;
                Program.stamina += 2;
                Program.jump += 2;
                Program.shotPower += 2;
                Program.reaction += 2;
                Program.agility += 2;
                Program.sprint += 2;
                Program.accel += 2;
                Program.passAc += 2;
                Program.headAc += 2;
                Program.shotAc += 2;
                Program.dribble += 2;
                Program.tackle += 2;
                Program.sliding += 2;
                Program.mantoman += 2;
                Program.positioning += 2;
                Program.vision += 2;
                Program.gk_handle += 2;
                Program.gk_onetoone += 2;
                Program.gk_diving += 2;

                Console.WriteLine("모든 능력치 가 +2 되었습니다.");

            }

            if (Coach.influence >= 10 && Coach.influence < 15)
            {

                Program.strength += 3;
                Program.stamina += 3;
                Program.jump += 3;
                Program.shotPower += 3;
                Program.reaction += 3;
                Program.agility += 3;
                Program.sprint += 3;
                Program.accel += 3;
                Program.passAc += 3;
                Program.headAc += 3;
                Program.shotAc += 3;
                Program.dribble += 3;
                Program.tackle += 3;
                Program.sliding += 3;
                Program.mantoman += 3;
                Program.positioning += 3;
                Program.vision += 3;
                Program.gk_handle += 3;
                Program.gk_onetoone += 3;
                Program.gk_diving += 3;

                Console.WriteLine("모든 능력치 가 +3 되었습니다.");

            }

            if (Coach.influence >= 15 && Coach.influence < 20)
            {

                Program.strength += 5;
                Program.stamina += 5;
                Program.jump += 5;
                Program.shotPower += 5;
                Program.reaction += 5;
                Program.agility += 5;
                Program.sprint += 5;
                Program.accel += 5;
                Program.passAc += 5;
                Program.headAc += 5;
                Program.shotAc += 5;
                Program.dribble += 5;
                Program.tackle += 5;
                Program.sliding += 5;
                Program.mantoman += 5;
                Program.positioning += 5;
                Program.vision += 5;
                Program.gk_handle += 5;
                Program.gk_onetoone += 5;
                Program.gk_diving += 5;

                Console.WriteLine("모든 능력치 가 +5 되었습니다.");

            }

            if (Coach.influence >= 20)
            {

                Program.strength += 10;
                Program.stamina += 10;
                Program.jump += 10;
                Program.shotPower += 10;
                Program.reaction += 10;
                Program.agility += 10;
                Program.sprint += 10;
                Program.accel += 10;
                Program.passAc += 10;
                Program.headAc += 10;
                Program.shotAc += 10;
                Program.dribble += 10;
                Program.tackle += 10;
                Program.sliding += 10;
                Program.mantoman += 10;
                Program.positioning += 10;
                Program.vision += 10;
                Program.gk_handle += 10;
                Program.gk_onetoone += 10;
                Program.gk_diving += 10;

                Console.WriteLine("모든 능력치 가 +10 되었습니다.");

            }

            if (buffNumb == 0)
            {
                Console.WriteLine("str = " + Program.strength + "+2");
                Program.strength += 2;
                Console.WriteLine("=" + Program.strength);
            }
            if (buffNumb == 1)
            {
                Console.WriteLine("stm = " + Program.stamina + "+2");
                Program.stamina += 2;
                Console.WriteLine("=" + Program.stamina);
            }
            if (buffNumb == 2)
            {
                Console.WriteLine("jmp = " + Program.jump + "+2");
                Program.jump += 2;
                Console.WriteLine("=" + Program.jump);
            }
            if (buffNumb == 3)
            {
                Console.WriteLine("sho = " + Program.shotPower + "+2");
                Program.shotPower += 2;
                Console.WriteLine("=" + Program.shotPower);
            }
            if (buffNumb == 4)
            {
                Console.WriteLine("rea = " + Program.reaction + "+2");
                Program.reaction += 2;
                Console.WriteLine("=" + Program.reaction);
            }
            if (buffNumb == 5)
            {
                Console.WriteLine("agi = " + Program.agility + "+2");
                Program.agility += 2;
                Console.WriteLine("=" + Program.agility);
            }
            if (buffNumb == 6)
            {
                Console.WriteLine("spr = " + Program.sprint + "+2");
                Program.sprint += 2;
                Console.WriteLine("=" + Program.sprint);
            }
            if (buffNumb == 7)
            {
                Console.WriteLine("acc = " + Program.accel + "+2");
                Program.accel += 2;
                Console.WriteLine("=" + Program.accel);
            }
            if (buffNumb == 8)
            {
                Console.WriteLine("pas = " + Program.passAc + "+2");
                Program.passAc += 2;
                Console.WriteLine("=" + Program.passAc);
            }
            if (buffNumb == 9)
            {
                Console.WriteLine("hea = " + Program.headAc + "+2");
                Program.headAc += 2;
                Console.WriteLine("=" + Program.headAc);
            }
            if (buffNumb == 10)
            {
                Console.WriteLine("sha = " + Program.shotAc + "+2");
                Program.shotAc += 2;
                Console.WriteLine("=" + Program.shotAc);
            }
            if (buffNumb == 11)
            {
                Console.WriteLine("drb = " + Program.dribble + "+2");
                Program.dribble += 2;
                Console.WriteLine("=" + Program.dribble);
            }
            if (buffNumb == 12)
            {
                Console.WriteLine("tac = " + Program.tackle + "+2");
                Program.tackle += 2;
                Console.WriteLine("=" + Program.tackle);
            }
            if (buffNumb == 13)
            {
                Console.WriteLine("sli = " + Program.sliding + "+2");
                Program.sliding += 2;
                Console.WriteLine("=" + Program.sliding);
            }
            if (buffNumb == 14)
            {
                Console.WriteLine("mtm = " + Program.mantoman + "+2");
                Program.mantoman += 2;
                Console.WriteLine("=" + Program.mantoman);
            }
            if (buffNumb == 15)
            {
                Console.WriteLine("pos = " + Program.positioning + "+2");
                Program.positioning += 2;
                Console.WriteLine("=" + Program.positioning);
            }
            if (buffNumb == 16)
            {
                Console.WriteLine("vis = " + Program.vision + "+2");
                Program.vision += 2;
                Console.WriteLine("=" + Program.vision);
            }
            if (buffNumb == 17)
            {
                Console.WriteLine("gkH = " + Program.gk_handle + "+2");
                Program.gk_handle += 2;
                Console.WriteLine("=" + Program.gk_handle);
            }
            if (buffNumb == 18)
            {
                Console.WriteLine("gkO = " + Program.gk_onetoone + "+2");
                Program.gk_onetoone += 2;
                Console.WriteLine("=" + Program.gk_onetoone);
            }
            if (buffNumb == 19)
            {
                Console.WriteLine("gkD = " + Program.gk_diving + "+2");
                Program.gk_diving += 2;
                Console.WriteLine("=" + Program.gk_diving);
            }

            if (debuffNumb == 0)
            {
                Console.WriteLine("str = " + Program.strength + "-2");
                Program.strength -= 2;
                Console.WriteLine("=" + Program.strength);
            }
            if (debuffNumb == 1)
            {
                Console.WriteLine("stm = " + Program.stamina + "-2");
                Program.stamina -= 2;
                Console.WriteLine("=" + Program.stamina);
            }
            if (debuffNumb == 2)
            {
                Console.WriteLine("jmp = " + Program.jump + "-2");
                Program.jump -= 2;
                Console.WriteLine("=" + Program.jump);
            }
            if (debuffNumb == 3)
            {
                Console.WriteLine("sho = " + Program.shotPower + "-2");
                Program.shotPower -= 2;
                Console.WriteLine("=" + Program.shotPower);
            }
            if (debuffNumb == 4)
            {
                Console.WriteLine("rea = " + Program.reaction + "-2");
                Program.reaction -= 2;
                Console.WriteLine("=" + Program.reaction);
            }
            if (debuffNumb == 5)
            {
                Console.WriteLine("agi = " + Program.agility + "-2");
                Program.agility -= 2;
                Console.WriteLine("=" + Program.agility);
            }
            if (debuffNumb == 6)
            {
                Console.WriteLine("spr = " + Program.sprint + "-2");
                Program.sprint -= 2;
                Console.WriteLine("=" + Program.sprint);
            }
            if (debuffNumb == 7)
            {
                Console.WriteLine("acc = " + Program.accel + "-2");
                Program.accel -= 2;
                Console.WriteLine("=" + Program.accel);
            }
            if (debuffNumb == 8)
            {
                Console.WriteLine("pas = " + Program.passAc + "-2");
                Program.passAc -= 2;
                Console.WriteLine("=" + Program.passAc);
            }
            if (debuffNumb == 9)
            {
                Console.WriteLine("hea = " + Program.headAc + "-2");
                Program.headAc -= 2;
                Console.WriteLine("=" + Program.headAc);
            }
            if (debuffNumb == 10)
            {
                Console.WriteLine("sha = " + Program.shotAc + "-2");
                Program.shotAc -= 2;
                Console.WriteLine("=" + Program.shotAc);
            }
            if (debuffNumb == 11)
            {
                Console.WriteLine("drb = " + Program.dribble + "-2");
                Program.dribble -= 2;
                Console.WriteLine("=" + Program.dribble);
            }
            if (debuffNumb == 12)
            {
                Console.WriteLine("tac = " + Program.tackle + "-2");
                Program.tackle -= 2;
                Console.WriteLine("=" + Program.tackle);
            }
            if (debuffNumb == 13)
            {
                Console.WriteLine("sli = " + Program.sliding + "-2");
                Program.sliding -= 2;
                Console.WriteLine("=" + Program.sliding);
            }
            if (debuffNumb == 14)
            {
                Console.WriteLine("mtm = " + Program.mantoman + "-2");
                Program.mantoman -= 2;
                Console.WriteLine("=" + Program.mantoman);
            }
            if (debuffNumb == 15)
            {
                Console.WriteLine("pos = " + Program.positioning + "-2");
                Program.positioning -= 2;
                Console.WriteLine("=" + Program.positioning);
            }
            if (debuffNumb == 16)
            {
                Console.WriteLine("vis = " + Program.vision + "-2");
                Program.vision -= 2;
                Console.WriteLine("=" + Program.vision);
            }
            if (debuffNumb == 17)
            {
                Console.WriteLine("gkH = " + Program.gk_handle + "-2");
                Program.gk_handle -= 2;
                Console.WriteLine("=" + Program.gk_handle);
            }
            if (debuffNumb == 18)
            {
                Console.WriteLine("gkO = " + Program.gk_onetoone + "-2");
                Program.gk_onetoone -= 2;
                Console.WriteLine("=" + Program.gk_onetoone);
            }
            if (debuffNumb == 19)
            {
                Console.WriteLine("gkD = " + Program.gk_diving + "-2");
                Program.gk_diving -= 2;
                Console.WriteLine("=" + Program.gk_diving);
            }

        }

    }

}
