CHANGES
// Help for the documentation

---------------------------
Class
baloni -> BaloonsPop
---------------------------
	Method
	gen -> GenerateField
---------------------------
		Variables
		temp -> generatedFiled
		randNumber -> randomGenerator
		tempByte -> currentRandomByteNumber (Initialized out of the loops)
---------------------------
	Method
	checkLeft -> checkForBaloonsLeft
	checkRight -> checkForBaloonsRight
	checkUp -> checkForBaloonsUp
	checkDoun -> checkForBaloonsDown
---------------------------
		Variables
		matrix -> gameField
		row -> chosenRow
		column -> choosenColumn
		newRow -> SearchingInRow
		newCol -> SearchingInCol
---------------------------
	Method
	change -> PopBaloon
---------------------------
		Variables
		matrixToModify -> gameField
		rowAtm -> chosenRow
		columnAtm ->chosenCol
		
---------------------------
	Method
	doit -> IsGameOver
---------------------------
		Variables
		matrix -> gameField
		stek -> remainingBaloons
		columnLnegnt -> rowsCount
		ADDNEW VARIABLE colsCount=gameField.GetLenght(1);
---------------------------
	Method
	sortAndPrintChartFive -> separete in two methods
				 SortPlayersRanking()
				 PrintRankList()
---------------------------
		Variables
		tableToSort -> playersRankingToSort
		klasirane -> ranking
		ADD NEW VARIALBE IN PrintRankList -> sortedChart
---------------------------
	Method
	Created new Method DrawGameField()
---------------------------
		Variables
		matrix -> gameField
---------------------------

Formatting
---------------------------
catch (IndexOutOfRangeException)    ->   
            { return; }		    ->

catch (IndexOutOfRangeException)
            {
                return;
            }

---------------------------
made GameField class public
moved BaloonsPop, StringExtensions and old StartGame code to _deprecated


TODO: 
 -Write Documentation (*write as you go, see https://www.youtube.com/watch?v=kh5lzpOEWRU)
	- update and git-push the TODO list before starting your turn
	- you can document changes as you go in the commit message
 
 - Create Command and Prompts enum for communication b/w Engine and IFrontEnd
	- Replace userCommand string with a Command enum
	- Replace Console.WriteLine messages with Prompts enum (which get rendered as Console.WriteLine messages in ConsoleUI)
 - (optional)Add DateTime field to RankList Reccord to make reccords more unique
 - Reduce Engine to under 150 loc (currently at 227 loc)
 - Separate GameLogic and Rendering
	- use separate class for Console work which only exchanges Input (commands) and Output(fieldState, error messages, top score list)
 - Create separate RankStorage class and a text file which holds the top scores
	- all requests for load/save scores go through it
	- ex: printing top scores 
			command print TopFive in Rendering Class
			pass Commands.PrintTopFive to Engine
			Engine request top scorer list from IStorage
			Engine pass TopFive as a List<RankListReccord> to IFrontEnd
			Rendering prints scores in Console by either ToString-ing each reccord or some other format by ToString-ing name, value, etc.
			(in this implementation IFrontEnd has to know what a RankListReccord is, alternative implementations might use formatted strings)
 - Use folders to organize groups of classes

 -Implement Desgin Patterns
 -SOLID principles
 -Create Unit Tests
 

