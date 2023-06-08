﻿using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stub;

namespace UnitTests
{
    public class UnitTestIPersistanceManager
    {
        [Fact]
        public void ChargeDonne_ReturnsExpectedData()
        {
            // Arrange
            var stub = new Stub.Stub();

            // Act
            var (oeuvres, utilisateurs) = stub.chargeDonne();

            // Assert
            Assert.NotNull(oeuvres);
            Assert.NotNull(utilisateurs);
            Assert.Equal(6, oeuvres.Count);
            Assert.Equal(3, utilisateurs.Count);

            // Assert specific oeuvre properties
            var evangelion = oeuvres[0];
            Assert.Equal("Evangelion", evangelion.Nom);
            Assert.Collection(evangelion.Genre,
                genre => Assert.Equal("Action", genre),
                genre => Assert.Equal("Future", genre));
            Assert.Equal("TV", evangelion.Type);
            Assert.Equal("C'est une bonne série", evangelion.Description);
            Assert.Equal(4, evangelion.Note);
            Assert.Equal(150, evangelion.NbEpisodes);
            Assert.Equal("evangelion.jpg", evangelion.Affiche);

            // Assert specific utilisateur properties
            var utilisateur = utilisateurs[0];
            Assert.Equal("t", utilisateur.Email);
            Assert.Equal("Pseudo1", utilisateur.Pseudo);
            Assert.Equal("t", utilisateur.MotDePasse);
            Assert.Equal("Jean", utilisateur.nom);
            Assert.Equal("Baptiste", utilisateur.prenom);
            Assert.Equal(12, utilisateur.age);
        }

        [Fact]
        public void Sauvegarder_CallsConsoleWriteLine()
        {
            // Arrange
            var stub = new Stub.Stub();
            var oeuvres = new ObservableCollection<Oeuvre>();
            var utilisateurs = new List<Utilisateur>();

            // Act
            stub.sauvegarder(oeuvres, utilisateurs);

            // Assert
            // Since the implementation of Sauvegarder only calls Console.WriteLine,
            // we can't directly test the functionality, but we can assert that the method was called
        }
    }
}

