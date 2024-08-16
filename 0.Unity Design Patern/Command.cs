using UnityEngine;
using System.Collections.Generic;

namespace SPACE.Command
{
    public class Command : MonoBehaviour
    {
        #region Private Fields

        private Block _block;
        private Stack<ICommand> _commands = new();

        #endregion

        private void Awake()
        {
            Debug.Log("Command Design Pattern example started.");

            _block = new Block();
            
            Debug.Log("Press 'A' to move left.");
            Debug.Log("Press 'D' to move right.");
            Debug.Log("Press 'U' to undo last move.");
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
                AddCommand(new MoveLeftCommand(_block));
            
            if (Input.GetKeyDown(KeyCode.D))
                AddCommand(new MoveRightCommand(_block));
            
            if (Input.GetKeyDown(KeyCode.U))
                UndoCommand();
        }

        private void AddCommand(ICommand command)
        {
            _commands.Push(command);
            command.Execute();
        }

        private void UndoCommand()
        {
            _commands.TryPop(out ICommand command);
            command?.Undo();
        }
    }

    public class Block
    {
        #region Private Fields

        private Vector2 _coordinate = Vector2.zero;

        #endregion

        public void Move(Vector2 direction)
        {
            _coordinate += direction;
            
            Debug.Log($"Current Coordinate : {_coordinate}");
        }
    }

    public interface ICommand
    {
        public void Execute();
        
        public void Undo();
    }

    public class MoveLeftCommand : ICommand
    {
        #region Private Fields

        private Block _block;

        #endregion
        
        public MoveLeftCommand(Block block)
        {
            _block = block;
        }
        
        public void Execute()
        {
            _block.Move(Vector2.left);
        }

        public void Undo()
        {
            _block.Move(Vector2.right);
        }
    }
    
    public class MoveRightCommand : ICommand
    {
        #region Private Fields

        private Block _block;

        #endregion
        
        public MoveRightCommand(Block block)
        {
            _block = block;
        }
        
        public void Execute()
        {
            _block.Move(Vector2.right);
        }

        public void Undo()
        {
            _block.Move(Vector2.left);
        }
    }
}   