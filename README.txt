PLEASE:
 -Write Documentation (*write as you go, see https://www.youtube.com/watch?v=kh5lzpOEWRU)
	- update and git-push the TODO list before starting your turn (this is only while we're coding one person at a time)
	- Document changes as you go in the COMMIT MESSAGE
		- first line is like Title or main-change [50 characters MAX!], 
			then _blank_ line, 
			then list of changes (add, move, reformat, etc.) if necessary, as in the example below
				ex:
				-------------------------COMMIT------------------------------------------	
				Refactor Engine to use Command objects

				Refactor Engine to use Command objects instead of strings
				Add Win() method to ConsoleUI
				Build - no Errors
				moved old change logs to _deprecated since now we use the commit messages
				--------------------------------------------------------------------------

TODO: 

 - ConsoleUI.RenderGameFieldState() --see comments
 - Implement Indexer[] in GameField instead of Get/SetFieldCell (http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx)
 - Implement GameField.Clone(destinationReference) method
	- frontEnd calls GameField.Clone(dRef), where dRef is the byte[,] field/property 
	in the frontEnd instance that should be overwritten by GameField, this way a new
	object is not created everytime Clone() is called, but frontEnd CANNOT change the 
	GameField w/o going through Engine by using commands
 -Create Unit Tests
 
 - Use folders to organize groups of classes
 - Implement methods that throw NotImplementedEception
 - [optional] Merge PopEngine directional methods into one method with help of PoppingDirection enum
 - [optional] Add DateTime field to RankList Reccord to make reccords more unique


 -Implement Desgin Patterns (at least 2 of each structural, behavior, creational)
	Behavior:
		- use Template Method pattern for PopBallons - Direction (Left,Right etc.)
		- use Iterator pattern for accessing elements in game-field
		- [done] use Command pattern for passing instructions from frontEnd to Engine 
		
 -SOLID principles
 
 

