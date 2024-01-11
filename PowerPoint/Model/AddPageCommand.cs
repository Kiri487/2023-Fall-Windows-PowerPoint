﻿using System.Collections.Generic;
using System.Linq;

namespace PowerPoint.Model
{
    public class AddPageCommand : ICommand
    {
        // Variable
        private List<Shapes> _pageList;
        private PageIndex _currentPageIndex;
        private int _previousPageIndex;

        public AddPageCommand(List<Shapes> pageList, PageIndex currentPageIndex, int previousPageIndex)
        {
            _pageList = pageList;
            _currentPageIndex = currentPageIndex;
            _previousPageIndex = previousPageIndex;
        }

        // Excute
        public void Execute()
        {
            _pageList.Insert(_previousPageIndex + 1, new Shapes());
            _currentPageIndex.SetPageIndex(_previousPageIndex + 1);

        }

        // Cancel excute
        public void CancelExecute()
        {
            _pageList.RemoveAt(_previousPageIndex + 1);
            _currentPageIndex.SubtractPageIndex();
        }
    }
}
