namespace DesingPattern.Iterator.IteratorPattern
{
    public class VisitRouteIterator : IIterator<VisitorRoute>
    {
        private VisitRouteMover _VisitRouteMover;

        public VisitRouteIterator(VisitRouteMover visitRouteMover)
        {
            _VisitRouteMover = visitRouteMover;
        }

        private int cuttentIndex = 0;
        public VisitorRoute CurrentItem {  get; set; }

        public bool NextLocation()
        {
            if (cuttentIndex < _VisitRouteMover.VisitRouteCount)
            {
                CurrentItem = _VisitRouteMover.visitorRoutes[cuttentIndex++];
                return true;
            }
            else
                return false;
        }
    }
}
