using StarMicronics.StarIOExtension;
using System.IO;

namespace StarPRNTSDK
{
    public class MelodySpeakerFunctions
    {
        public static byte[] CreatePlayingRegisteredSoundData(MelodySpeakerModel model, bool specifySound, MelodySpeakerSoundStorageArea soundStorageArea, int soundNumber, bool specifyVolume, int volume)
        {
            IMelodySpeakerCommandBuilder builder = StarIoExt.CreateMelodySpeakerCommandBuilder(model);

            SoundSetting setting = new SoundSetting();

            if (specifySound)
            {
                setting.SoundStorageArea = soundStorageArea;
                setting.SoundNumber = soundNumber;
            }

            if (specifyVolume)
            {
                setting.Volume = volume;
            }

            builder.AppendSound(setting);

            return builder.Commands;
        }

        public static byte[] CreatePlayingSoundData(MelodySpeakerModel model, string filePath, bool specifyVolume, int volume)
        {
            byte[] data = null;

            using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                data = new byte[stream.Length];
                stream.Read(data, 0, data.Length);
            }

            IMelodySpeakerCommandBuilder builder = StarIoExt.CreateMelodySpeakerCommandBuilder(model);

            SoundSetting setting = new SoundSetting();

            if (specifyVolume)
            {
                setting.Volume = volume;
            }

            builder.AppendSoundData(data, setting);

            return builder.Commands;
        }
    }
}
