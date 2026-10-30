# AISecureCodeStudy

How secure is AI-generated code? This project measures how often AI coding
assistants produce vulnerable C# code, and whether explicitly asking for secure
code reduces the vulnerability rate compared to a bare prompt.

## Objective
1. Design realistic coding prompts across common task categories.
2. Generate code with an AI assistant using two prompt types:
   - **Bare prompt**: task only, no security instruction.
   - **Secure prompt**: same task plus explicit security requirements.
3. Scan all outputs with a SAST tool (Semgrep).
4. Categorize findings by CWE and compare vulnerability rates.

## Tools Used
| Purpose | Tool |
|---|---|
| Code generation | AI coding assistant (GitHub Copilot / ChatGPT / Claude) |
| SAST scanning | Semgrep 1.181.0 |
| Language / runtime | C#, .NET 10 |
| Analysis | PowerShell (parsing Semgrep JSON) |

## Project Structure
```
AISecureCodeStudy/
├── Samples/
│   ├── Basic/      # code from bare prompts
│   └── Secure/     # code from secure prompts
├── Results/
│   ├── basic-scan.json
│   └── secure-scan.json
├── Program.cs
├── AISecureCodeStudy.csproj
└── README.md
```

## Test Cases
| ID | Category | Vulnerability | CWE |
|---|---|---|---|
| SQL01 | Database query | SQL Injection | CWE-89 |
| INP01 | User input | Cross-Site Scripting | CWE-79 |
| FIL01 | File upload | Path Traversal / Unrestricted Upload | CWE-22, CWE-434 |
| AUTH01 | Authentication | Weak Hashing, Hardcoded Credentials | CWE-327, CWE-798 |
| CMD01 | OS command | Command Injection | CWE-78 |

## How to Run
Prerequisites: .NET SDK, Python, and Semgrep (`pip install semgrep`).

```powershell
# Scan bare-prompt code
semgrep --config auto Samples\Basic --json -o Results\basic-scan.json

# Scan secure-prompt code
semgrep --config auto Samples\Secure --json -o Results\secure-scan.json

# Summarize vulnerability rate
foreach ($m in "basic","secure") {
  $j = Get-Content "Results\$m-scan.json" -Raw | ConvertFrom-Json
  $total = $j.paths.scanned.Count
  $vuln = ($j.results | Select -Expand path -Unique).Count
  "{0}: {1}/{2} files vulnerable = {3:P0}" -f $m,$vuln,$total,($vuln/$total)
}
```

## Limitations
- Small sample size; results are indicative, not statistically conclusive.
- Semgrep may produce false negatives and false positives.
- Results depend on the AI model and prompt wording used.

## References
- Pearce et al., "Asleep at the Keyboard? Assessing the Security of GitHub Copilot's Code Contributions" (2022)
- Semgrep: https://semgrep.dev
- CWE: https://cwe.mitre.org