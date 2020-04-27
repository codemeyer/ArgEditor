using ArgData;

namespace ArgEditor.Features.CarSetupEditing
{
    public class SetupFileLoader
    {
        public void Load(SetupViewModel viewModel, string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                return;

            var data = new SetupReader().ReadSingle(path);

            Mappers.Mapper.MapCarSetupToViewModel(data, viewModel);
        }
    }
}
