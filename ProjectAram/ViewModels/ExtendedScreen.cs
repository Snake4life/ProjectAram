using System.ComponentModel.Composition;
using Caliburn.Micro;
using ProjectAram.Properties;

namespace ProjectAram.ViewModels
{
    public abstract class ExtendedScreen : Screen
    {
        #region Fields

        protected readonly IEventAggregator _eventAgg;
        protected IWindowManager _windowManager;
        protected readonly Settings _settings;

        public bool IsEnabled;
        #endregion

        #region Properties

        public string TabName { get; set; }

        public virtual bool IsTabEnabled { get; set; }

        public virtual byte[] BackgroundImage { get; set; }

        #endregion

        #region Constructor

        [ImportingConstructor]
        protected ExtendedScreen(IEventAggregator eventAgg, IWindowManager windowManager, Settings settings)
        {
            _eventAgg = eventAgg;
            _settings = settings;
            _windowManager = windowManager;
            _eventAgg.Subscribe(this);
        }

        #endregion

        /// <summary>
        /// Set background image
        /// </summary>
        /// <param name="image"></param>
        protected virtual void SetBackgroundImage(byte[] image)
        {
            BackgroundImage = image;
        }
    }
}