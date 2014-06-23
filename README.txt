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

 - Reduce Engine to under 150 loc
 - Separate GameLogic and Rendering
	- use separate class for Console work which only exchanges Input (commands) and Output(fieldState, error messages, top score list)
 - create separate RankStorage class and a text file which holds the top scores
	- all requests for load/save scores go through it
	- ex: printing top scores 
			command print top in Rendering Class
			pass to Engine
			Engine request top score list from RankStorage (should Rendering be able to ask RankStorage directly?)
			Engine pass top5 to Rendering Class
			Rendering prints scores in Console
 - use folders to organize groups of classes
	- put old files in 'Deprecated' folder

 -Implement Desgin Patterns
 -SOLID principles
 -Create Unit Tests
 

