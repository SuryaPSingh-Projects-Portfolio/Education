# QuizMaster - Interactive Quiz Application

A modern, interactive quiz application built with HTML, CSS, and JavaScript that tests your knowledge across multiple technology topics.

## 🎯 Features

- **Multiple Topics**: C#, SQL, Grafana, AI, JavaScript, Python, Docker, Git
- **Customizable Quiz Length**: Choose 5, 10, 15, 20, or 25 questions
- **Custom Topic Support**: Type in your own topic (validates against available topics)
- **Randomized Questions**: Each quiz generates a unique set of questions
- **Timer**: Tracks how long it takes to complete the quiz
- **Detailed Results**: Shows correct answers with explanations (under 200 words each)
- **Responsive Design**: Works on desktop and mobile devices
- **Modern UI**: Beautiful gradient design with smooth animations

## 🚀 How to Run

1. Start a local web server in this folder (required so `questions.json` loads):

   ```bash
   npx --yes serve .
   ```

   Or: `python -m http.server 8080`

2. Open the URL shown (e.g. `http://localhost:3000`) in your browser
3. Built-in topics (C#, SQL, Grafana, AI, etc.) work offline with 25+ curated MCQs each
4. Custom topics use online AI generation (via Puter.js) when the local bank has no questions

## 📋 How to Use

1. **Enter Your Name**: Type your name in the input field
2. **Select a Topic**: Choose from the dropdown or select "Other (Custom)" to type your own
3. **Choose Question Count**: Select how many questions you want (5-25)
4. **Start Quiz**: Click the "Start Quiz" button
5. **Answer Questions**: Click on options to select your answer
6. **Navigate**: Use Previous/Next buttons to move between questions
7. **Finish**: Complete all questions to see your results
8. **Review**: Check your score, percentage, and detailed explanations for each question

## 🏗️ Architecture

### High-Level Structure

```
QuizMaster (Single Page Application)
├── HTML Structure
│   ├── Welcome Screen (name input, topic selection, question count)
│   ├── Quiz Screen (timer, question display, options, navigation)
│   └── Results Screen (score, percentage, detailed answers)
├── CSS Styling
│   ├── Modern gradient design
│   ├── Responsive layout
│   └── Interactive animations
└── JavaScript Logic
    ├── Question Bank (data structure)
    ├── Quiz State Management
    ├── DOM Manipulation
    └── Event Handling
```

### Component Breakdown

#### 1. HTML Structure

The application uses a single-page design with three main screens:

**Welcome Screen** (`#welcomeScreen`)
- Input field for user name
- Dropdown for topic selection
- Custom topic input (hidden by default, shown when "Other" is selected)
- Question count selector (5, 10, 15, 20, 25)
- Start Quiz button

**Quiz Screen** (`#quizScreen`)
- Timer display (MM:SS format)
- Progress indicator (Question X of Y)
- Question card with question text
- Options container (dynamically generated)
- Previous/Next navigation buttons

**Results Screen** (`#resultsScreen`)
- Score display with greeting based on performance
- Percentage calculation
- Scrollable results list showing:
  - Question number and text
  - User's answer (color-coded: green for correct, red for incorrect)
  - Correct answer (if user was wrong)
  - Explanation (concise, under 200 words)
- "Take Another Quiz" button

#### 2. CSS Styling

The CSS uses modern design principles:

- **Gradient Background**: Purple gradient (`#667eea` to `#764ba2`)
- **Card-based Layout**: White container with rounded corners and shadow
- **Responsive Design**: Media queries for mobile devices
- **Interactive Elements**: Hover effects, transitions, and animations
- **Color Coding**: Green for correct answers, red for incorrect

Key CSS Classes:
- `.container`: Main application container
- `.welcome-screen`, `.quiz-screen`, `.results-screen`: Screen containers
- `.form-group`: Input field styling
- `.btn`: Button styling with hover effects
- `.question-card`: Question display area
- `.option`: Answer option styling
- `.option.selected`: Highlighted selected answer
- `.result-item.correct` / `.result-item.incorrect`: Result styling

#### 3. JavaScript Logic

The JavaScript is organized into several key sections:

**A. Question Bank Data Structure**

```javascript
const questionBank = {
    csharp: [
        {
            question: "Question text here",
            options: ["Option A", "Option B", "Option C", "Option D"],
            correct: 2,  // Index of correct answer (0-3)
            explanation: "Concise explanation under 200 words"
        },
        // ... more questions
    ],
    sql: [ /* ... */ ],
    // ... other topics
};
```

Each topic contains an array of question objects. Each question has:
- `question`: The question text
- `options`: Array of 4 possible answers
- `correct`: Index (0-3) of the correct answer
- `explanation`: Explanation text (under 200 words)

**B. Quiz State Management**

```javascript
let currentQuestions = [];      // Questions for current quiz
let userAnswers = [];           // User's answers (indexes)
let currentQuestionIndex = 0;   // Current question number
let userName = '';              // User's name
let selectedTopic = '';         // Selected topic key
let questionCount = 25;         // Number of questions (5-25)
let timerInterval;              // Timer reference
let timeElapsed = 0;            // Time in seconds
```

**C. Key Functions**

1. **`startQuiz()`** - Initializes the quiz
   - Validates user input (name, topic)
   - Handles custom topic validation
   - Selects random questions based on count
   - Switches from welcome to quiz screen
   - Starts timer
   - Loads first question

2. **`shuffleArray(array)`** - Randomizes array order
   - Uses Fisher-Yates shuffle algorithm
   - Ensures random question selection each quiz

3. **`startTimer()`** - Starts the countdown timer
   - Updates every second
   - Formats time as MM:SS
   - Stores in `timeElapsed` variable

4. **`loadQuestion()`** - Displays current question
   - Updates question number and text
   - Generates option elements dynamically
   - Highlights previously selected answer
   - Updates navigation buttons

5. **`selectOption(index)`** - Handles answer selection
   - Stores user's answer in `userAnswers` array
   - Updates UI to show selected option

6. **`previousQuestion()`** - Navigates to previous question
   - Decrements `currentQuestionIndex`
   - Reloads question with saved answer

7. **`nextQuestion()`** - Navigates to next question
   - Increments `currentQuestionIndex`
   - Triggers `finishQuiz()` on last question

8. **`finishQuiz()`** - Calculates and displays results
   - Stops timer
   - Calculates correct answers and percentage
   - Generates results HTML
   - Switches to results screen

9. **`restartQuiz()`** - Resets for new quiz
   - Resets all state variables
   - Returns to welcome screen

**D. Event Listeners**

```javascript
// Show/hide custom topic input based on dropdown selection
document.getElementById('topicSelect').addEventListener('change', function() {
    const customTopicGroup = document.getElementById('customTopicGroup');
    if (this.value === 'custom') {
        customTopicGroup.style.display = 'block';
    } else {
        customTopicGroup.style.display = 'none';
    }
});
```

## 🔧 How to Add New Topics/Questions

### Adding a New Topic

1. Add a new key to the `questionBank` object:
```javascript
const questionBank = {
    // ... existing topics
    react: [
        {
            question: "What is React?",
            options: ["A database", "A JavaScript library", "A framework", "A language"],
            correct: 1,
            explanation: "React is a JavaScript library for building user interfaces, developed by Facebook."
        },
        // Add more questions (aim for 25-30)
    ]
};
```

2. Add the topic to the HTML dropdown:
```html
<option value="react">React</option>
```

3. Update the hint text in the custom topic input to include the new topic

### Adding Questions to Existing Topics

Simply add new question objects to the appropriate topic array in the `questionBank`:

```javascript
csharp: [
    // ... existing questions
    {
        question: "Your new question here",
        options: ["Option A", "Option B", "Option C", "Option D"],
        correct: 0,  // Index of correct answer (0 = first option)
        explanation: "Your explanation here (keep under 200 words)"
    }
]
```

**Guidelines for Questions:**
- Each question must have exactly 4 options
- The `correct` value must be 0, 1, 2, or 3 (index of correct option)
- Explanations should be concise (under 200 words)
- Aim for 25-30 questions per topic for variety

## 🎨 Customization

### Changing Colors

Modify the gradient in the CSS:
```css
body {
    background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
}
```

### Changing Question Count Options

Modify the HTML dropdown:
```html
<select id="questionCount">
    <option value="5">5 Questions</option>
    <option value="10">10 Questions</option>
    <!-- Add or remove options as needed -->
</select>
```

### Modifying Score Thresholds

Update the greeting logic in `finishQuiz()`:
```javascript
document.getElementById('resultGreeting').textContent = 
    percentage >= 80 ? 'Excellent!' : 
    percentage >= 60 ? 'Good Job!' : 
    percentage >= 40 ? 'Keep Practicing!' : 'Need More Study!';
```

## 🔍 How It Works: Step-by-Step Flow

1. **Initialization**
   - User opens `index.html` in browser
   - JavaScript loads and defines `questionBank` object
   - Welcome screen is displayed

2. **User Input**
   - User enters name and selects topic
   - If "Other (Custom)" is selected, custom input field appears
   - User selects question count (5-25)

3. **Quiz Start**
   - `startQuiz()` function validates inputs
   - Custom topic is validated against `questionBank` keys
   - Questions are shuffled and sliced to selected count
   - Timer starts counting from 00:00
   - First question loads

4. **Quiz Progression**
   - User clicks options to select answers
   - `selectOption()` saves answer and updates UI
   - User navigates with Previous/Next buttons
   - Timer continues counting
   - Progress updates (Question X of Y)

5. **Quiz Completion**
   - On last question, "Next" becomes "Finish"
   - `finishQuiz()` calculates score and percentage
   - Results HTML is generated dynamically
   - Timer stops
   - Results screen displays

6. **Restart**
   - User clicks "Take Another Quiz"
   - `restartQuiz()` resets all state
   - Welcome screen displays again

## 📊 Data Flow Diagram

```
User Input → Validation → Question Selection → Quiz Interface
                                              ↓
                                         User Answers
                                              ↓
                                         Score Calculation
                                              ↓
                                         Results Display
```

## 🛠️ Technical Details

### Browser Compatibility
- Works in all modern browsers (Chrome, Firefox, Safari, Edge)
- Uses ES6 JavaScript features (const, let, arrow functions, template literals)
- No external dependencies required

### Performance
- Single file loads quickly
- No network requests after initial load
- Efficient DOM manipulation
- Minimal memory footprint

### Security
- No server-side code (client-side only)
- No user data is stored or transmitted
- Safe to run offline

## 🐛 Troubleshooting

**Quiz doesn't start when clicking button:**
- Check browser console for JavaScript errors (F12)
- Ensure all question objects have valid structure
- Verify custom topic name matches a key in `questionBank`

**Questions not displaying correctly:**
- Ensure each question has exactly 4 options
- Check that `correct` index is 0-3
- Verify explanation text is present

**Timer not working:**
- Check if `setInterval` is being cleared properly
- Ensure timer element has correct ID

## 📝 Future Enhancements

Potential improvements for the application:
- Add sound effects for correct/incorrect answers
- Implement difficulty levels (easy, medium, hard)
- Add leaderboard functionality
- Include hints for difficult questions
- Add category filtering within topics
- Implement dark mode toggle
- Add progress bar visualization
- Save quiz history to localStorage

## 📄 License

This project is open source and available for educational purposes.

## 👤 Author

Created as an interactive learning tool for technology professionals and students.

---

**Happy Learning! 🎓**
