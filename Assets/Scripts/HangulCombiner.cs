using System;

class HangulCombiner
{
    // 한글 유니코드의 시작값
    const int HangulBase = 0xAC00;

    // 초성, 중성, 종성 개수
    const int JungSeongCount = 21;
    const int JongSeongCount = 28;

    // 초성, 중성, 종성 문자 배열
    private static readonly char[] ChoSeongArray = { 'ㄱ', 'ㄲ', 'ㄴ', 'ㄷ', 'ㄸ', 'ㄹ', 'ㅁ', 'ㅂ', 'ㅃ', 'ㅅ', 'ㅆ', 'ㅇ', 'ㅈ', 'ㅉ', 'ㅊ', 'ㅋ', 'ㅌ', 'ㅍ', 'ㅎ' };
    private static readonly char[] JungSeongArray = { 'ㅏ', 'ㅐ', 'ㅑ', 'ㅒ', 'ㅓ', 'ㅔ', 'ㅕ', 'ㅖ', 'ㅗ', 'ㅘ', 'ㅙ', 'ㅚ', 'ㅛ', 'ㅜ', 'ㅝ', 'ㅞ', 'ㅟ', 'ㅠ', 'ㅡ', 'ㅢ', 'ㅣ' };
    private static readonly char[] JongSeongArray = { '\0', 'ㄱ', 'ㄲ', 'ㄳ', 'ㄴ', 'ㄵ', 'ㄶ', 'ㄷ', 'ㄹ', 'ㄺ', 'ㄻ', 'ㄼ', 'ㄽ', 'ㄾ', 'ㄿ', 'ㅀ', 'ㅁ', 'ㅂ', 'ㅄ', 'ㅅ', 'ㅆ', 'ㅇ', 'ㅈ', 'ㅊ', 'ㅋ', 'ㅌ', 'ㅍ', 'ㅎ' };

    // 자음과 모음 문자를 받아 한글 문자로 조합
    public static char CombineHangul(char cho, char jung = '\0', char jong = '\0')
    {
        int choIndex = Array.IndexOf(ChoSeongArray, cho);
        int jungIndex = Array.IndexOf(JungSeongArray, jung);
        int jongIndex = Array.IndexOf(JongSeongArray, jong);
        
        if (jungIndex == -1)
        {
            return cho;
        }

        if (choIndex == -1 || jungIndex == -1 || jongIndex == -1)
        {
            return ' ';
        }

        int unicode = HangulBase + (choIndex * JungSeongCount * JongSeongCount) + (jungIndex * JongSeongCount) + jongIndex;
        return (char)unicode;
    }

    static void Main()
    {
        try
        {
            char result = CombineHangul('ㄱ', 'ㅏ', 'ㄱ'); // "각" 생성
            Console.WriteLine(result); // 출력: 각

            result = CombineHangul('ㅂ', 'ㅏ'); // "바" 생성 (종성 없음)
            Console.WriteLine(result); // 출력: 바
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}