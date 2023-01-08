﻿using SynologyNet.Exceptions;
using SynologyNet.Models.Responses.Photo;
using SynologyNet.Repository;
using SynologyNet.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SynologyNet.Services
{
    class PhotoStationPersonalService : BaseService, IPhotoStationPersonalService
    {
        private PersonalPhotoRepository Repository { get; }

        public PhotoStationPersonalService()
            => Repository = new PersonalPhotoRepository();

        public async Task<IEnumerable<Folder>> GetFolders()
        {
            var response = await Repository.GetFolders();

            CheckErrorCode(response);

            return response.Data.List;
        }

        public async Task<IEnumerable<Album>> GetAlbums()
        {
            var response = await Repository.GetAlbums();

            CheckErrorCode(response);

            return response.Data.List;
        }

        public async Task<IEnumerable<Album>> GetSharedAlbums()
        {
            var response = await Repository.GetSharedAlbums();

            CheckErrorCode<PhotoErrorCode>(response);

            return response.Data.List;
        }

        public async Task<IEnumerable<Photo>> GetPhotos()
        {
            var response = await Repository.GetPhotos();

            CheckErrorCode<PhotoErrorCode>(response);

            return response.Data.List;
        }

        public async Task<IEnumerable<Photo>> GetSharedAlbumPhotos(Album album)
        {
            var response = await Repository.GetSharedAlbumPhotos(album);

            CheckErrorCode<PhotoErrorCode>(response);

            return response.Data.List;
        }

        public async Task<IEnumerable<Photo>> GetAlbumPhotos(Album album)
        {
            var response = await Repository.GetAlbumPhotos(album);

            CheckErrorCode<PhotoErrorCode>(response);

            return response.Data.List;
        }

        public async Task<IEnumerable<Photo>> GetRecentlyAddedPhotos()
        {
            var response = await Repository.GetRecentlyAddedPhotos();

            CheckErrorCode<PhotoErrorCode>(response);

            return response.Data.List;
        }

        public async Task<byte[]> DownloadPhoto(int photoId)
        {
            var response = await Repository.DownloadPhoto(photoId, null);

            CheckErrorCode<PhotoErrorCode>(response);

            return response.Data;
        }

        public async Task<byte[]> DownloadPhoto(int photoId, string passphrase)
        {
            var response = await Repository.DownloadPhoto(photoId, passphrase);

            CheckErrorCode<PhotoErrorCode>(response);

            return response.Data;
        }

        public Task<byte[]> DownloadPhoto(Photo photo)
        {
            return DownloadPhoto(photo.Id);
        }

        public Task<byte[]> DownloadPhoto(Photo photo, Album album)
        {
            return DownloadPhoto(photo.Id, album.Passphrase);
        }
    }
}
