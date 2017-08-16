using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;
public class codemaker : MonoBehaviour
{
    public int kazu = 0;
    public string code = "";
    //easyなら1、normalなら2、hardなら3
    public GameObject automatic;
    automaticgenerator script;
    private static List<char> rokujuuyonnlist = new List<char>(){//256進数！！
    '0', '1', '2', '3', '4', '5', '6', '7', '8', '9','a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j','k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N','O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X','Y', 'Z', '+', '/',
        'Α','Β','Γ','Δ','Ε','Ζ','Η','Θ','Ι','Κ','Λ','Μ','Ν','Ξ','Ο','Π','Ρ','Σ','Τ','Υ','Φ','Χ','Ψ','Ω','α','β','γ','δ','ε','ζ','η','θ','ι','κ','λ','μ','ν','ξ','ο','π','ρ','σ','τ','υ','φ','χ','ψ','ω','А','Б','В','Г','Д','Е','Ё','Ж','З','И','Й','К','Л','М','Н','О','П','Р','С','Т','У','Ф','Х','Ц','Ч','Ш','Щ','Ъ','Ы','Ь','Э','Ю','Я','а','б','в','г','д','е','ё','ж','з','и','й','к','л','м','н','о','п','р','с','т','у','ф','х','ц','ч','ш','щ','ъ','ы','ь','э','ю','я',
        '＋','－','±','×','÷','＝','≒','≠','≦','≧','＜','＞','≪','≫','∞','∽','∝','∴','∵','∈','∋','⊆','⊇','⊂','⊃','∪','∩','∧','∨','￢','⇒','⇔','∀','∃','∠','⊥','⌒','∂','∇','≡','√','∫','∬','─','│','┌','┐','┘','└','├','┬','┤','┴','┼','━','┃','┏','┓','┛','┗','┣','┳','┫','┻','╋','┠','┯','┨','┷','┿','┝','┰','┥','┸','╂','＃','＆','＊','＠','§','※','〓','♯','♭','♪','†','‡','¶','仝','々','〆','ー','～','￣','＿','―','‐','∥','｜','／','＼'
  };
    public static string nisinnsuukara64sinnsuu(string num)
    {
        int digit = (1 + ((int)(num.Length - 1) / 8)) *8;
        num = num.PadLeft(digit, '0');
        string rokujuuyon = "";
        for (int i = 0; i < num.Length; i += 8)
        {
            int no = Convert.ToInt32(num.Substring(i, 8), 2);
            rokujuuyon += rokujuuyonnlist[no];
        }
        return rokujuuyon;
    }

    public string easy()
    {
        return code;
    }
    public string normal()
    {
        var goal = new Stack<int>();
        automatic = GameObject.Find("mapgenerator");
        script = automatic.GetComponent<automaticgenerator>();
        int[,] map = script.map;
        code += "2";
        for (int i = 1; i < 17; i++)
        {
            string ichigyou = "";
            for (int j = 1; j < 17; j++)
            {
                if (map[i, j] == 2) { goal.Push(i); goal.Push(j); continue; }
                if (i % 2 == 0)
                {
                    if (j % 2 == 0)
                    {
                        continue;
                    }
                    else
                    {
                        ichigyou += map[i, j].ToString();
                    }
                }
                else
                {
                    if (j % 2 == 0)
                    {
                        ichigyou += map[i, j].ToString();
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            code += nisinnsuukara64sinnsuu(ichigyou);
        }
        code += "#";
        foreach (var item in goal)
        {
            code += rokujuuyonnlist[item];
        }
        return code;
    }
    public string hard()
    {
        return code;
    }

}
