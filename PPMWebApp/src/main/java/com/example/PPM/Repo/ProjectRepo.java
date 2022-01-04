package com.example.PPM.Repo;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.example.PPM.Model.Project;

@Repository
public interface ProjectRepo extends JpaRepository<Project, Integer>
{

}
