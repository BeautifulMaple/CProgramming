using System.Collections.Generic;

class Collection
{
    static void Main(string[] args)
    {
        // Collection
        // Length x Count를 사용하여 개수를 구함
        List<int> numbers = new List<int>(); // 빈 리스트 생성
        numbers.Add(1); // 리스트에 데이터 추가
        numbers.Add(2);
        numbers.Add(3);
        numbers.Remove(2); // 리스트에서 데이터 삭제

        for (int i = 0; i < numbers.Count; i++)
        {
            // [i]를 통해서 인덱싱을 할 수 있다.
            Console.WriteLine(numbers[i]);
        }

        // numbers에 있는 것을 number에 넣어두겠다.
        foreach (int number in numbers) // 리스트 데이터 출력
        {
            Console.WriteLine(number);
        }


        Dictionary<string, int> scores = new Dictionary<string, int>(); // 빈 딕셔너리 생성
        scores.Add("Alice", 100); // 딕셔너리에 데이터 추가
        scores.Add("Bob", 80);
        scores.Add("Charlie", 90);
        scores.Remove("Bob"); // 딕셔너리에서 데이터 삭제

        foreach (KeyValuePair<string, int> pair in scores) // 딕셔너리 데이터 출력
        {
            Console.WriteLine(pair.Key + ": " + pair.Value);
        }

        Stack<int> stack1 = new Stack<int>();  // int형 Stack 선언

        // Stack에 요소 추가
        stack1.Push(1);
        stack1.Push(2);
        stack1.Push(3);

        // Stack에서 요소 가져오기
        int value = stack1.Pop(); // value = 3 (마지막에 추가된 요소)

        Queue<int> queue1 = new Queue<int>(); // int형 Queue 선언

        // Queue에 요소 추가
        queue1.Enqueue(1);
        queue1.Enqueue(2);
        queue1.Enqueue(3);

        // Queue에서 요소 가져오기
        int value1 = queue1.Dequeue(); // value = 1 (가장 먼저 추가된 요소)

        HashSet<int> set1 = new HashSet<int>();  // int형 HashSet 선언

        // HashSet에 요소 추가
        set1.Add(1);
        set1.Add(2);
        set1.Add(3);

        // HashSet에서 요소 가져오기
        foreach (int element in set1)
        {
            Console.WriteLine(element);
        }
    }
}