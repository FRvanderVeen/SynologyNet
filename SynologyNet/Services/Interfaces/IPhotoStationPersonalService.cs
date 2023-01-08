﻿using SynologyNet.Models.Responses.Photo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SynologyNet.Services.Interfaces
{
    /// <summary>
    /// PersonalSpace for PhotoStation interface
    /// </summary>
    public interface IPhotoStationPersonalService
    {
        /// <summary>
        /// Get list of albums made by the current user
        /// </summary>
        /// <returns>List of albums</returns>
        Task<IEnumerable<Album>> GetAlbums();

        /// <summary>
        /// Get list of shared albums with the current user
        /// </summary>
        /// <returns>List of shared albums</returns>
        Task<IEnumerable<Album>> GetSharedAlbums();

        /// <summary>
        /// Get a list of photos from the current user
        /// </summary>
        /// <returns>List of photos</returns>
        Task<IEnumerable<Photo>> GetPhotos();

        /// <summary>
        /// Get list of recently added photos
        /// </summary>
        /// <returns>List of photos</returns>
        Task<IEnumerable<Photo>> GetRecentlyAddedPhotos();

        /// <summary>
        /// Get list of photos from a specified <seealso cref="Album"/>
        /// </summary>
        /// <param name="album">Source <seealso cref="Album"/></param>
        /// <returns>List of photos</returns>
        Task<IEnumerable<Photo>> GetAlbumPhotos(Album album);

        /// <summary>
        /// Get list of shared <seealso cref="Album"/> photos with the current user
        /// </summary>
        /// <param name="album">Shared <seealso cref="Album"/></param>
        /// <returns>List of shared <seealso cref="Photo"/> within a <paramref name="album"/></returns>
        Task<IEnumerable<Photo>> GetSharedAlbumPhotos(Album album);

        /// <summary>
        /// Get list of folders
        /// </summary>
        /// <returns>List of folders</returns>
        Task<IEnumerable<Folder>> GetFolders();

        /// <summary>
        /// Download <seealso cref="Photo"/> as byte array
        /// </summary>
        /// <param name="photoId"><seealso cref="Photo"/> identifier</param>
        /// <returns>Photo as byte array</returns>
        Task<byte[]> DownloadPhoto(int photoId);

        /// <summary>
        /// Download <seealso cref="Photo"/> as byte array
        /// </summary>
        /// <param name="photo"><seealso cref="Photo"/> to download</param>
        /// <returns>Photo as bytearray</returns>
        Task<byte[]> DownloadPhoto(Photo photo);

        /// <summary>
        /// Download <seealso cref="Photo"/> from shared <seealso cref="Album"/> as byte array
        /// </summary>
        /// <param name="photoId"><seealso cref="Photo"/> identifier</param>
        /// <param name="passphrase">Shared <seealso cref="Album"/> passphrase</param>
        /// <returns>Photo as byte array</returns>
        Task<byte[]> DownloadPhoto(int photoId, string passphrase);

        /// <summary>
        /// Download <seealso cref="Photo"/> from shared <seealso cref="Album"/> as byte array
        /// </summary>
        /// <param name="photo"><seealso cref="Photo"/> to download</param>
        /// <param name="album">Source <seealso cref="Album"/></param>
        /// <returns></returns>
        Task<byte[]> DownloadPhoto(Photo photo, Album album);
    }
}
