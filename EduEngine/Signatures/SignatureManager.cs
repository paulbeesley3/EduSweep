#region copyright-header
/*
 * This file is part of EduSweep.
 * Copyright 2008 - 2019 Paul Beesley
 *
 * EduSweep is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * EduSweep is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with EduSweep. If not, see <https://www.gnu.org/licenses/>.
 */
#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EdUtils.Detections;
using EdUtils.Filesystem;
using EdUtils.Types;
using Newtonsoft.Json;
using NLog;

namespace EduEngine.Signatures
{
    public static class SignatureManager
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Get the number of signatures.
        /// </summary>
        /// <returns>The total number of signatures, both built-in and custom.</returns>
        public static int GetCount(SignatureType type)
        {
            return GetSignatureList(type).Count;
        }

        /// <summary>
        /// Get a list of Signature instances, each representing a single signature.
        /// </summary>
        public static List<Signature> GetSignatureList(SignatureType type)
        {
            var signatureList = new List<Signature>();
            var searchFolders = new List<DirectoryInfo>();

            switch (type)
            {
                case SignatureType.BUILTIN:
                    searchFolders.Add(new DirectoryInfo(AppFolders.SignatureFolder));
                    break;
                case SignatureType.CUSTOM:
                    searchFolders.Add(new DirectoryInfo(AppFolders.CustomSignatureFolder));
                    break;
                case SignatureType.ALL:
                    searchFolders = AppFolders.SignatureFolderList;
                    break;
                default:
                    break;
            }

            foreach (DirectoryInfo dir in searchFolders)
            {
                try
                {
                    foreach (FileInfo file in dir.GetFiles("*.json", SearchOption.TopDirectoryOnly))
                    {
                        signatureList.Add(LoadSignature(file));
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(
                        ex,
                        string.Format("Unable to search for signatures in directory: {0}", dir));
                }
            }

            return signatureList;
        }

        /// <summary>
        /// Get the complete list of signature elements provided by all available signatures.
        /// </summary>
        public static List<SignatureElement> GetSignatureElementsList(SignatureType type)
        {
            var signatureList = GetSignatureList(type);
            var signatureElementList = new List<SignatureElement>();

            foreach (Signature sig in signatureList)
            {
                signatureElementList = signatureElementList.Union(
                    sig.Elements,
                    new SignatureElementComparer()).ToList();
            }

            return signatureElementList;
        }

        /// <summary>
        /// Get a list of available signature elements of a given detection type.
        /// </summary>
        public static List<SignatureElement> GetSignatureElementsList(
            SignatureType sigType,
            DetectionType type)
        {
            var signatureElementList = GetSignatureElementsList(sigType);

            var filteredList = from element in signatureElementList
                               where element.Type == type
                               select element;

            return filteredList.ToList();
        }

        /// <summary>
        /// Deserialize a single signature.
        /// </summary>
        /// <param name="guid">Unique identifer of the signature.</param>
        /// <returns>Deserialized Signature instance corresponding to the GUID.</returns>
        public static Signature GetSignature(Guid guid)
        {
            List<Signature> sigList = GetSignatureList(SignatureType.ALL);
            foreach (var signature in sigList)
            {
                if (signature.Guid.Equals(guid))
                {
                    return signature;
                }
            }

            logger.Error("Missing signature file for GUID {0}", guid.ToString());
            throw new FileNotFoundException("Expected signature file was missing");
        }

        /// <summary>
        /// Delete a signature file.
        /// </summary>
        /// <param name="sig">The signature instance to be deleted from disk.</param>
        public static void RemoveSignature(Signature sig)
        {
            string path = Path.Combine(
                AppFolders.CustomSignatureFolder,
                string.Format("{0}.json", sig.Guid));
            try
            {
                File.Delete(path);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Failed to delete signature at {0}.", path);
                throw;
            }
        }

        /// <summary>
        /// Create a Signature instance by deserializing a JSON representation on disk.
        /// </summary>
        /// <param name="file">Signature instance representing the serialized Signature on disk.</param>
        /// <returns>A deserialized Signature instance.</returns>
        private static Signature LoadSignature(FileInfo file)
        {
            string json;

            try
            {
                using (var fileReader = new StreamReader(file.FullName, true))
                {
                    json = fileReader.ReadToEnd();
                }

                return JsonConvert.DeserializeObject<Signature>(json, SerializerSettings.Settings);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Failed to load signature from {0}", file.FullName);
                throw;
            }
        }
    }
}
