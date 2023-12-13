﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PowerPoint.Model.Tests
{
    [TestClass()]
    public class MoveCommandTests
    {
        MoveCommand _moveCommand;
        Shapes _shapes = new Shapes();
        CoordinatePoint _startPoint = new CoordinatePoint(10, 20);
        CoordinatePoint _endPoint = new CoordinatePoint(30, 50);
        CoordinatePoint _movedStartPoint = new CoordinatePoint(10 + OFFSET_X, 20 + OFFSET_Y);
        CoordinatePoint _movedEndPoint = new CoordinatePoint(30 + OFFSET_X, 50 + OFFSET_Y);
        const float OFFSET_X = 10;
        const float OFFSET_Y = 20;
        const string LINE = "線";
        const string RECTANGLE = "矩形";
        const string CIRCLE = "橢圓";

        // Initialize
        [TestInitialize()]
        public void Initialize()
        {
        }

        // Line execute test
        [TestMethod()]
        public void LineExecuteTest()
        {
            _shapes.SetDrawingShapeName(LINE);
            _shapes.AddShape(_startPoint, _endPoint);
            _moveCommand = new MoveCommand(_shapes, OFFSET_X, OFFSET_Y);

            Assert.IsFalse(_shapes.IsSelect());
            _moveCommand.Execute();
            Assert.AreEqual(_movedStartPoint.ToString(), _shapes.GetShapeStartPoint(0).ToString());
            Assert.AreEqual(_movedEndPoint.ToString(), _shapes.GetShapeEndPoint(0).ToString());
            Assert.IsFalse(_shapes.IsSelect());
        }

        // Rectangle execute test
        [TestMethod()]
        public void RectangleExecuteTest()
        {
            _shapes.SetDrawingShapeName(RECTANGLE);
            _shapes.AddShape(_startPoint, _endPoint);
            _moveCommand = new MoveCommand(_shapes, OFFSET_X, OFFSET_Y);

            Assert.IsFalse(_shapes.IsSelect());
            _moveCommand.Execute();
            Assert.AreEqual(_movedStartPoint.ToString(), _shapes.GetShapeStartPoint(0).ToString());
            Assert.AreEqual(_movedEndPoint.ToString(), _shapes.GetShapeEndPoint(0).ToString());
            Assert.IsFalse(_shapes.IsSelect());
        }

        // Circle execute test
        [TestMethod()]
        public void CircleExecuteTest()
        {
            _shapes.SetDrawingShapeName(CIRCLE);
            _shapes.AddShape(_startPoint, _endPoint);
            _moveCommand = new MoveCommand(_shapes, OFFSET_X, OFFSET_Y);

            Assert.IsFalse(_shapes.IsSelect());
            _moveCommand.Execute();
            Assert.AreEqual(_movedStartPoint.ToString(), _shapes.GetShapeStartPoint(0).ToString());
            Assert.AreEqual(_movedEndPoint.ToString(), _shapes.GetShapeEndPoint(0).ToString());
            Assert.IsFalse(_shapes.IsSelect());
        }

        // Line execute test (already select)
        [TestMethod()]
        public void LineAlreadySelectExecuteTest()
        {
            _shapes.SetDrawingShapeName(LINE);
            _shapes.AddShape(_startPoint, _endPoint);
            _moveCommand = new MoveCommand(_shapes, OFFSET_X, OFFSET_Y);

            _shapes.SetSelectShape(0);
            _moveCommand.Execute();
            Assert.AreEqual(_movedStartPoint.ToString(), _shapes.GetShapeStartPoint(0).ToString());
            Assert.AreEqual(_movedEndPoint.ToString(), _shapes.GetShapeEndPoint(0).ToString());
            Assert.IsTrue(_shapes.IsSelect());
        }

        // Rectangle execute test (already select)
        [TestMethod()]
        public void RectangleAlreadySelectExecuteTest()
        {
            _shapes.SetDrawingShapeName(RECTANGLE);
            _shapes.AddShape(_startPoint, _endPoint);
            _moveCommand = new MoveCommand(_shapes, OFFSET_X, OFFSET_Y);

            _shapes.SetSelectShape(0);
            _moveCommand.Execute();
            Assert.AreEqual(_movedStartPoint.ToString(), _shapes.GetShapeStartPoint(0).ToString());
            Assert.AreEqual(_movedEndPoint.ToString(), _shapes.GetShapeEndPoint(0).ToString());
            Assert.IsTrue(_shapes.IsSelect());
        }

        // Circle execute test (already select)
        [TestMethod()]
        public void CircleAlreadySelectExecuteTest()
        {
            _shapes.SetDrawingShapeName(CIRCLE);
            _shapes.AddShape(_startPoint, _endPoint);
            _moveCommand = new MoveCommand(_shapes, OFFSET_X, OFFSET_Y);

            _shapes.SetSelectShape(0);
            _moveCommand.Execute();
            Assert.AreEqual(_movedStartPoint.ToString(), _shapes.GetShapeStartPoint(0).ToString());
            Assert.AreEqual(_movedEndPoint.ToString(), _shapes.GetShapeEndPoint(0).ToString());
            Assert.IsTrue(_shapes.IsSelect());
        }

        // Line cancel execute test
        [TestMethod()]
        public void LineCancelExecuteTest()
        {
            _shapes.SetDrawingShapeName(LINE);
            _shapes.AddShape(_startPoint, _endPoint);
            _moveCommand = new MoveCommand(_shapes, OFFSET_X, OFFSET_Y);

            _moveCommand.Execute();
            _moveCommand.CancelExecute();
            Assert.AreEqual("(10, 20)", _shapes.GetShapeStartPoint(0).ToString());
            Assert.AreEqual("(30, 50)", _shapes.GetShapeEndPoint(0).ToString());
        }

        // Rectangle cancel execute test
        [TestMethod()]
        public void RectangleCancelExecuteTest()
        {
            _shapes.SetDrawingShapeName(RECTANGLE);
            _shapes.AddShape(_startPoint, _endPoint);
            _moveCommand = new MoveCommand(_shapes, OFFSET_X, OFFSET_Y);

            _moveCommand.Execute();
            _moveCommand.CancelExecute();
            Assert.AreEqual("(10, 20)", _shapes.GetShapeStartPoint(0).ToString());
            Assert.AreEqual("(30, 50)", _shapes.GetShapeEndPoint(0).ToString());
        }

        // Circle cancel execute test
        [TestMethod()]
        public void CircleCancelExecuteTest()
        {
            _shapes.SetDrawingShapeName(CIRCLE);
            _shapes.AddShape(_startPoint, _endPoint);
            _moveCommand = new MoveCommand(_shapes, OFFSET_X, OFFSET_Y);

            _moveCommand.Execute();
            _moveCommand.CancelExecute();
            Assert.AreEqual("(10, 20)", _shapes.GetShapeStartPoint(0).ToString());
            Assert.AreEqual("(30, 50)", _shapes.GetShapeEndPoint(0).ToString());
        }
    }
}