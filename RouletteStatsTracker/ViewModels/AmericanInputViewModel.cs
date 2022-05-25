﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RouletteStatsTracker.Helpers;
using RouletteStatsTracker.Models;

namespace RouletteStatsTracker.ViewModels
{
    public class AmericanInputViewModel
    {
        public ObservableCollection<String> NumberList { get; set; }
        private Stack<String> OverFlow { get; set; }
        public ICommand  DataButtonCommand { get; set; }
        public ICommand DeleteButtonCommand { get; set; }
        
        private AmericanDataService dataService;    //Acts on the data set using methods for the American wheel, Add, Delete etc..
        
        public AmericanInputViewModel()
        {
            dataService = ServiceHelper.GetService<AmericanDataService>();

            NumberList = new ObservableCollection<string>();

            OverFlow = new Stack<string>();
            
            /* Defining event handlers similar to JavaFX */
            DataButtonCommand = new Command<string>(execute: (string arg) =>
            {
                NumberList.Insert(0, arg);

                int cutoff = 13;    //Define different values for different platforms
                
                if(NumberList.Count > cutoff)
                {
                    OverFlow.Push(NumberList[NumberList.Count - 1]);
                    NumberList.RemoveAt(NumberList.Count - 1);
                }
                
                dataService.Add(arg);

            });

            DeleteButtonCommand = new Command(execute: () =>
            {
                if(NumberList.Count == 0) return;

                dataService.Delete(NumberList[0]);                  
                
                if(OverFlow.Count != 0)
                {
                    NumberList.Add(OverFlow.Pop());
                }

                NumberList.RemoveAt(0);
            });
        }
    }
}
