using System;
using CQRSlite.Commands;

namespace Domain.Commands
{
    public class BaseCommand : ICommand
    {
        public Guid Id { get; set; }
        
        public int ExpectedVersion { get; set; }
    }
}