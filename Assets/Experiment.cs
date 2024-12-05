using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Experiment : MonoBehaviour
{
    public Controller controller;
    
    public TMP_Text currentSentenceText;
    public TMP_Text timerText;
    public Button startButton;
    
    private string _resultText;

    private int _dataIndex = 0;
    private int _dataLimit;
    private readonly string[] _testSet = new string[60];
    private string[] _textFile;
    
    // 현재 테스트 문장의 인덱스
    private int _currentSentenceIndex = 0;
    // 현재 테스트 문장
    private string _currentSentence;
    // 실험 시작 시간
    private float _startTime;
    // 실험 종료 시간
    private float _endTime;
    // 총 입력한 글자수
    private int _totalInputChars = 0;
    // 총 오류수
    private int _totalErrors = 0;

    // 실험 종료 여부
    private bool _isEnd = false;
    
    // 실험 시작 여부
    private bool _isExperimentRunning = false;

    private void Start()
    {
        controller.OnEnterAction += OnEnter;
        startButton.onClick.AddListener(RunExperiment);

        LoadData();
    }

    private void OnEnter()
    {
        if (!_isExperimentRunning) return;
         OnInputEnd(controller.virtualKeyboardView.text.Trim());
         controller.virtualKeyboardView.text = "";
    }

    private void Update()
    {
        if (_isExperimentRunning)
        {
            // 남은 시간 0:00 형식으로 표시
            timerText.text = $"{4 - (int)(Time.time - _startTime) / 60:00}:{59 - (int)(Time.time - _startTime) % 60:00}";
            
            if (Time.time - _startTime >= 10)
            {
                EndExperiment();
            }
        }
    }
    
    void OnInputEnd(string input)
    {
        if (!_isExperimentRunning) return;

        var inputLength = input.Length;
        var targetLength = _currentSentence.Length;

        var errors = CalculateErrors(input, _currentSentence);
        _totalInputChars += inputLength;
        _totalErrors += errors;
        
        DisplayNextSentence();
    }

    private void DisplayNextSentence()
    {
        if (_currentSentenceIndex < 60)
        {
            _currentSentence = _testSet[_currentSentenceIndex++];
            currentSentenceText.text = _currentSentence;
        }
        else
        {
            _isEnd = true;
            EndExperiment();
        }
    }

    int CalculateErrors(string input, string target)
    {
        int errors = 0;
        int minLength = Mathf.Min(input.Length, target.Length);

        for (int i = 0; i < minLength; i++)
        {
            if (input[i] != target[i])
            {
                errors++;
            }
        }

        if (input.Length > target.Length)
        {
            errors += input.Length - target.Length;
        }
        
        return errors;
    }

    private void EndExperiment()
    {
        _endTime = Time.time;
        float timeTaken = _endTime - _startTime; // 초 단위
        // 분당 단어수
        float wpm = (float)_totalInputChars / 5 / (timeTaken / 60f);
        
        // 오류율
        float errorRate = 100;
        if(_totalInputChars == 0)
            errorRate = 0;
        else 
            errorRate = (float)_totalErrors / _totalInputChars * 100f;

        _isExperimentRunning = false;
        _resultText = $"WPM: {wpm:F2}\n오류율: {errorRate:F2}%";
        currentSentenceText.text = "";
        timerText.text = "0:00";
        Debug.Log(_resultText);

        SaveResult(wpm, errorRate);
    }

    private void SaveResult(float wpm, float errorRate)
    {
        var filePath = Path.Combine(Application.persistentDataPath, "results.csv");
        // var delimiter = ",";
        
        // 첫 실행 시 헤더 작성
        if (!File.Exists(filePath))
        {
            string header = "SentenceIndex,Sentence,WPM,ErrorRate\n";
            File.WriteAllText(filePath, header);
        }
        
        string data = $"{_currentSentenceIndex},{_currentSentence},{wpm:F2},{errorRate:F2}\n";
        File.AppendAllText(filePath, data);
    }

    private void RunExperiment()
    {
        // 테스트 데이터 로드
        GetTestSet();

        // 인덱스 초기화
        _currentSentenceIndex = 0;
        
        _isExperimentRunning = true;

        // 실험 시작 시간
        _startTime = Time.time;
        _endTime = 0;
        
        _totalInputChars = 0;
        _totalErrors = 0;
        _isEnd = false;
        
        
        _currentSentence = _testSet[_currentSentenceIndex];
        currentSentenceText.text = _currentSentence;
    }

    // 데이터 파일 로드
    private void LoadData()
    {
        // 데이터 파일
        _textFile = File.ReadAllLines("Assets/Data/data.txt");
        _dataLimit = _textFile.Length;
        // 데이터 파일을 섞음
        Shuffle(_textFile);
    }
    
    // 데이터 셋을 60개 단위로 분할해 테스트 셋을 만듦
    private void GetTestSet()
    {
        for (var i = 0; i < 60; i++)
        {
            _testSet[i] = _textFile[_dataIndex++];
        }
        
        // 테스트 셋을 출력
        for (var i = 0; i < 60; i++)
        {
            Debug.Log($"{i}: {_testSet[i]}");
        }
    }

    // 데이터 셋의 각 줄을 랜덤하게 섞음
    private void Shuffle(string[] array)
    {
        var n = array.Length;
        while (n > 1)
        {
            n--;
            var k = Random.Range(0, n);
            (array[k], array[n]) = (array[n], array[k]);
        }
    }
}
