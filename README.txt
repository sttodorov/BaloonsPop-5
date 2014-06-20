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



TODO: 
 -Place all magic numbers in GameConstants static class.
 -catch Exception: when user enters String.Empty command and presses Enter
 -Separate BaloonsPop class
 -Inplement Desgin Patterns
 -SOLID principles
 -Create Unit Tests
 -Write Documentation

