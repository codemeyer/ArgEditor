using ArgData;
using ArgEditor.ViewModels;

namespace ArgEditor.Interactors
{
    public class SetupFileLoader
    {
        public void Load(SetupViewModel viewModel, string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                return;

            var data = SetupReader.ReadSingle(path);

            Mappers.Mapper.MapCarSetupToViewModel(data, viewModel);
        }
    }
}
