# QATEST
# CloudQA Automation Tests  
**Technologies:** C#, .NET 10, Selenium WebDriver, NUnit  
**Author:** Surya Yeturu  

This repository contains three automated UI tests developed as part of the **CloudQA Developer Internship** assignment.  
The tests interact with the CloudQA Automation Practice Form and are designed to remain stable even when HTML structure or element positions change.

---

## 🚀 Project Overview

The automation script covers the following fields on the form:

### ✔️ Test 1 — First Name & Last Name  
- Locates input fields using robust XPath  
- Enters sample data  
- Verifies the entered value

### ✔️ Test 2 — Gender Selection  
- Selects the first gender radio button (Male)  
- Uses fallback selectors for stability  
- Verifies the selection

### ✔️ Test 3 — Country Selection & Submit  
- Selects “India” from the dropdown (or fallback option)  
- Clicks the Submit button  
- Ensures interaction completes successfully  

All tests run using **WebDriverWait** to handle dynamic loading.

---

## 🧰 Prerequisites

Install the following before running the tests:

1. **.NET SDK 8, 9, or 10**  
   https://dotnet.microsoft.com/en-us/download

2. **Google Chrome**

3. **Required NuGet Packages** (installed automatically via `dotnet restore`):
   - Selenium.WebDriver  
   - Selenium.Support  
   - Selenium.WebDriver.ChromeDriver  
   - NUnit  

---

## 📦 Installation

Clone the repository:

```bash
git clone https://github.com/surya-yeturu/QATEST.git
cd QATEST
dotnet restore
