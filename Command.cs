using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaloonsPopGame
{
    public class Command
    {
        private object data;
        
        /// <summary>
        /// Contains details of a command returned by the UI to the Engine.
        /// Types are limited to only those that Engine can process.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="data">Optional piece of data such as userName string or most commonly coordinates for a Pop</param>
        public Command(CommandType type, object data = null) 
        {
            this.Type = type;
            this.Data = data;
            
        }
        
        public CommandType Type {get; private set;}

        public object Data 
        { 
            get 
            {
                if ((this.Type != CommandType.PopBalloonAt) && (this.data == null))
                {
                    throw new InvalidOperationException("Command has not Data");
                }
                return this.data;
            } 
            private set 
            {
                if (this.Type == CommandType.PopBalloonAt)
                {
                    if (value == null)
                    {
                        throw new ArgumentNullException("Balloon coordinates cannot be null");
                    }
                    
                    this.data = value;
                }
                else
                {
                    this.data = null;
                }
            } 
        }


    }
}
