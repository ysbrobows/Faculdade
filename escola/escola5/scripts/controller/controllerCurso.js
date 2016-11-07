var app = angular.module('app', []);

app.controller('CursoController', function ($scope, $http) {
    $scope.Cursos = [];
    $scope.curso = "";

    $scope.ListarCursos = function () {
        $http.post("/Curso/Listar").then(function (response) {
            $scope.Cursos = response.data;
        });
    }

    $scope.DeletarCurso = function (id) {
        $http.post("/Curso/Deletar", { id: id }).then(function (response) {
            $scope.ListarCursos();
        });
    }
    $scope.SalvarCurso = function () {
        alert("entrou");

        if ($scope.curso.ID) {
            $http.post("/Curso/Editar", { curso: $scope.curso }).success(function (response) {
                if (!response) {
                    alert("Erro: Esse curso ja existe")
                }
                $scope.curso = null;
                $scope.ListarCursos();
            })
        }
        else {
            $http.post("/Curso/Salvar", { curso: $scope.curso }).success(function (response) {
                if (!response) {
                    alert("Erro: Esse curso ja existe")
                }
                $scope.ListarCursos();
            })
        }
    }
    $scope.EditarCurso = function (objeto) {
        $scope.curso = objeto;
    }

    $scope.init = function () {
        $scope.ListarCursos();
    }

    $scope.init();

});
