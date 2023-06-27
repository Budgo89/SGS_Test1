using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "AddressPrefabsGallery", menuName = "SGS/AddressPrefabsGallery", order = 0)]
    public class AddressPrefabsGallery : ScriptableObject
    {
        [SerializeField] private string _addressPrefabs;
        [SerializeField] private string _addressContentImage;
        [SerializeField] private string _addressSavePicture;

        public string AddressPrefabs => _addressPrefabs;
        public string AddressContentImage => _addressContentImage;
        public string AddressSavePicture => _addressSavePicture;
    }
}